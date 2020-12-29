using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace GM.Infrastructure.GetOnlineFiles
{
    public class USA_TX_TravisCounty_Austin_CityCouncil_en
    {
        readonly string austinDomain = "https://www.austintexas.gov";
        readonly string councilInfo = "https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm";
        //string meetingDesc = "Regular Meeting of the Austin City Council";

        //string nextMeetingLink = "https://www.austintexas.gov/department/city-council/2020/20200507-reg.htm";
        //string transcriptLink = "https://www.austintexas.gov/edims/document.cfm?id=339945";


        // We only want regular meetings of city council
        // We will pass this function as a comparator on description to GetNextMeetingLink()
        public bool CheckDescription(string desc)
        {
            string lower = desc.ToLower();
            return (lower.Contains("regular meeting") && lower.Contains("city council"));
        }
        public delegate bool CallBack(string description);


        public bool Do(DateTime lastMeetingTime, string outputFolder)
        {
            CallBack descCallBack = new CallBack(CheckDescription);

            GetNextMeetingLink(lastMeetingTime, descCallBack, out DateTime time, out string link);
            if (link == "") return false;

            string transcriptLink = GetTranscriptLink(link);

            GetPdf(transcriptLink, out byte[] result);

            string className = GetType().Name;
            string timeString = time.ToString("yyyy-mm-dd");
            string filename = className + "_" + timeString + ".pdf";
            string outputPath = Path.Combine(outputFolder, filename);

            File.WriteAllBytes(outputPath, result);
            return true;
        }

        /* There are 2 HTML tables on the Council Meeting Info Center page.
        * The 1st contains the upcoming meetings.
        * The 2nd contains the recent past meetngs.
        * We want the link to the next (past) meeting after the last one that we processed.
        */
        private void GetNextMeetingLink(DateTime lastMeeting, CallBack checkDescription, out DateTime time, out string link)
        {
            // Get the tables on the page
            DataSet dataSet = HtmlTablesToDataset(councilInfo);

            // The recent meetings are in the second table
            DataTable dt = dataSet.Tables[1];

            DateTime nextMeetingDate = DateTime.Now;
            string nextMeetingUrl = "";

            // Find the next meeting after what was passed in as "lastMeeting"
            foreach (DataRow row in dt.Rows)
            {
                string desc = row["Desc"].ToString();

                if (checkDescription(desc))
                {
                    DateTime date = (DateTime)(row["Date"]);
                    if ((date > lastMeeting) && (date < nextMeetingDate))
                    {
                        nextMeetingDate = date;
                        nextMeetingUrl = row["Url"].ToString();
                    }
                }
            }
            link = nextMeetingUrl;
            time = nextMeetingDate;
        }

        private string GetTranscriptLink(string nextMeetingLink)
        {
            HtmlDocument doc = new HtmlWeb().Load(nextMeetingLink);

            // Find the <a> element whose innerHtml is "Transcript"
            // Extract the url
            string url = doc.DocumentNode
                .SelectSingleNode("//a[. = 'Transcript']")
                .Attributes["href"].Value;

            return url;
        }




        /* Extract the HTML tables from the page as C# "DataTables".
         * There are 2 tables: upcoming and recent past meetings.
         * Each table has 3 columns: Date, Description and Url to the meeting's page.
         */
        private DataSet HtmlTablesToDataset(string link)
        {
            var resultDataset = new DataSet();

            HtmlDocument doc = new HtmlWeb().Load(link);

            int tableNum = 0;

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                //if (++tableNum == 1) continue;
                var resultTable = new DataTable("table" + ++tableNum);

                resultTable.Columns.Add("Date", typeof(DateTime));
                resultTable.Columns.Add("Desc", typeof(string));
                resultTable.Columns.Add("Url", typeof(string));

                DataRow dataRow = null;

                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    var dataCells = row.SelectNodes("td");
                    if (dataCells != null)
                    {
                        dataRow = resultTable.NewRow();
                        if (!DateTime.TryParse(dataCells[0].InnerText, out DateTime dateValue))
                        {
                            break;
                        }
                        dataRow["Date"] = dateValue;
                        dataRow["Desc"] = dataCells[1].InnerText.Trim();
                        dataRow["Url"] = austinDomain + dataCells[2]
                            .SelectSingleNode("a")
                            .Attributes["href"].Value;
                        resultTable.Rows.Add(dataRow);
                    }
                }
                resultDataset.Tables.Add(resultTable);
            }
            return resultDataset;
        }

        /* Retrieve the transcript PDF file.
         * The url link to the transcript will return a response of type "application/pdf; charset=UTF-8".
         * We need to read the streaming response into a MemoryStream.
         */
        private void GetPdf(string url, out byte[] result)
        {
            byte[] buffer = new byte[4096];
            int totalCount = 0;

            WebRequest wr = WebRequest.Create(url);

            using WebResponse response = wr.GetResponse();
            // Display all the Headers present in the response received from the URl.
            Console.WriteLine("\nThe following headers were received in the response");

            // Display each header and it's key , associated with the response object.
            for (int i = 0; i < response.Headers.Count; ++i)
                Console.WriteLine("\nHeader Name:{0}, Header value :{1}", response.Headers.Keys[i], response.Headers[i]);

            using Stream responseStream = response.GetResponseStream();
            using MemoryStream memoryStream = new MemoryStream();
            int count = 0;
            do
            {
                count = responseStream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, count);
                totalCount += count;

            } while (count != 0);

            result = memoryStream.ToArray();
        }


    }
}

/* LAYOUT OF THE "RECENT MEETINGS" TABLE  - This is the second table on the page

<table border="1" frame="hsides" rules="rows" cellspacing="0" cellpadding="5" width="700">

<tr valign="top" bgcolor="#e1e1e1">
	<td width="75">
		<p class="edims_no_indent"><b>5/21/2020</b></p>
	</td>
	<td width="500">
		<p class="edims_no_indent">Regular Meeting of the Austin City Council</p>
	</td>
	<td align="center" width="125">
		<a style="font-weight:bold;font-size:10pt" href="/department/city-council/2020/20200521-reg.htm">Meeting Details</a> 
	</td>
</tr>

<tr valign="top" bgcolor="#ffffff">
	<td width="75">
		<p class="edims_no_indent"><b>5/21/2020</b></p>
	</td>
	<td width="500">
		<p class="edims_no_indent">Meeting of the Austin Housing Finance Corporation (AHFC) Board of Directors</p>
	</td>
	<td align="center" width="125">
		<a style="font-weight:bold;font-size:10pt" href="/department/city-council/2020/20200521-ahfc.htm">Meeting Details</a> 
	</td>
</tr>

... 
 */
