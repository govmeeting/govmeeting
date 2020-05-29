using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace GetOnlineFiles_Lib
{
    public class USA_TX_TravisCounty_Austin_CityCouncil_en
    {

        string austin = "https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm";

        public void Do()
        {
            DataSet res = HtmlTablesToDataset(austin);
        }


        public DataSet HtmlTablesToDataset(string link)
        {
            var resultDataset = new DataSet();

            HtmlDocument doc = new HtmlWeb().Load(link);

            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(html);

            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                var resultTable = new DataTable(table.Id);

                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    var headerCells = row.SelectNodes("th");
                    if (headerCells != null)
                    {
                        foreach (HtmlNode cell in headerCells)
                        {
                            resultTable.Columns.Add(cell.InnerText);
                        }
                    }

                    var dataCells = row.SelectNodes("td");
                    if (dataCells != null)
                    {
                        var dataRow = resultTable.NewRow();
                        for (int i = 0; i < dataCells.Count; i++)
                        {
                            dataRow[i] = dataCells[i].InnerText;
                        }

                        resultTable.Rows.Add(dataRow);
                    }
                }

                resultDataset.Tables.Add(resultTable);
            }

            return resultDataset;
        }





        private string[] ParseHtmlSplitTables(string urlLink)
        {
            string[] result = new string[] { };

            HtmlDocument htmlDoc = new HtmlWeb().Load(urlLink);

            HtmlNodeCollection tableNodes = htmlDoc.DocumentNode.SelectNodes("//table");
                if (tableNodes != null)
                {
                    result = Array.ConvertAll<HtmlNode, string>(tableNodes.ToArray(), n => n.OuterHtml);
                }

            return result;
        }

        private void xxx(string html)
        {
                //List<List<KeyValuePair<string, string>>> parseResult = ParseHtmlToDataTable(html);

                //DataTable dataTable = ToDataTable(parseResult);
        }

        DataTable ToDataTable(List<List<KeyValuePair<string, string>>> list)
        {
            DataTable result = new DataTable();
            if (list.Count == 0)
                return result;

            result.Columns.AddRange(
                list.First().Select(r => new DataColumn(r.Value)).ToArray()
                );



            list = list.Skip(1).ToArray().ToList();
            list.ForEach(r => result.Rows.Add(r.Select(c => c.Value).Cast<object>().ToArray()));


            return result;
        }

        // https://stackoverflow.com/questions/59498328/iterate-through-web-pages-and-download-pdfs

        public void DoOther()
        {
            HtmlDocument htmlDoc = new HtmlWeb().Load("https://www.nordicwater.com/products/waste-water/");

            HtmlNodeCollection ProductListPage = htmlDoc.DocumentNode.SelectNodes("//a[@class='ap-area-link']");
            Console.WriteLine("Here are the links:" + ProductListPage);

            if (ProductListPage != null)
            {
                foreach (HtmlNode src in ProductListPage)
                {
                    string href = src.GetAttributeValue("href", string.Empty);
                    if (string.IsNullOrEmpty(href))
                        continue;
                    htmlDoc = new HtmlWeb().Load(href);

                    // Thread.Sleep(5000); // wait some time

                    // "//div[@class='dl-items']//a" means find a <div> element with class "dl-items" and within it find an <a> element
                    HtmlNodeCollection LinkTester = htmlDoc.DocumentNode.SelectNodes("//div[@class='dl-items']//a");
                    if (LinkTester != null)
                    {
                        foreach (var dllink in LinkTester)
                        {
                            // LinkURL will be the link to the file
                            string LinkURL = dllink.GetAttributeValue("href", string.Empty);
                            if (string.IsNullOrEmpty(LinkURL))
                                continue;

                            // ExtraceFilename will be the filename, which is the part of the link after the last "/"
                            string ExtractFilename = LinkURL.Substring(LinkURL.LastIndexOf("/") + 1);

                            // Thread.Sleep(5000); // wait some time

                            // Download the file and put in C:\temp\filename
                            new WebClient().DownloadFileAsync(new Uri(LinkURL), @"C:\temp\" + ExtractFilename);
                        }
                    }
                }
            }
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
