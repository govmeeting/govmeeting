using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

#pragma warning disable IDE0051

namespace GM.Utilities.DevelopRetrieval
{
    class ParseSplitSample
    {
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
    }
}
