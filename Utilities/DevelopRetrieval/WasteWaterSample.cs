using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace GM.Utilities.DevelopRetrieval
{
    class WasteWaterSample
    {
        // https://stackoverflow.com/questions/59498328/iterate-through-web-pages-and-download-pdfs

        public void Do()
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
