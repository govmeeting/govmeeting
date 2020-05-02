using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GM.FileDataRepositories;
using GM.GoogleCLoud;
using Microsoft.Toolkit.Parsers.Markdown;

namespace GM.Utilities.Translate
{
    class TranslateDocs
    {
        TranslateInCloud translateInCloud;

        public TranslateDocs(TranslateInCloud _translateInCloud)
        {
            translateInCloud = _translateInCloud;
        }

        public void Run(string[] args)
        {
            List<string> languages = new List<string>()
                { "fr", "hi", "de", "ar", "sw", "zh", "pt" , "bn" };

            foreach (string lang in languages)
            {
                DoLanguage(lang);
            };
        }



        public void DoLanguage(string language)
        {
            string folder = @"C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp\src\assets\docs";
            //string language = "es";

            //string folder = args[1];
            //string language = args[2];

            //ParseMarkdown();
            //RenderMarkdown();

            var files = from f in Directory.EnumerateFiles(folder)
                        where f.EndsWith(".en.md")
                        select f;
            foreach (string f in files)
            {
                string newFile = f.Replace(".en.md", "." + language + ".md");

                if (!File.Exists(newFile))
                {
                    string contents = GMFileAccess.Readfile(f);
                    var htmlContents = CommonMark.CommonMarkConverter.Convert(contents);
                    string htmlFile = f.Replace(".en.md", ".en.html");
                    File.WriteAllText(htmlFile, htmlContents);

                    string translated = translateInCloud.TranslateHtml(htmlContents, language);
                    //string htmlNewFile = f.Replace(".en.md", "." + language + ".html");
                    //File.WriteAllText(htmlNewFile, translated);

                    string replaced = ReplaceSomeStrings(translated);
                    File.WriteAllText(newFile, replaced);

                    // Wait 10 seconds. GCP didn't like me running a close loop.
                    Task.Delay(10000).Wait();
                }
            }
        }

        // The TranslateHtml method removes most newlines from the output. This makes it difficult to check for validity.
        // We try to put back newlines in appropriate places.
        // We also replace the HTML escape sequences with the actual characters. We don't use escape sequences in the markdown.
        private string ReplaceSomeStrings(string text)
        {
            var rpls = new Dictionary<string, string>
            {
                {" ____", "\n____" },
                {" C # ", " C# "},
                {" # ", "\n# " },
                {" ## ", "\n## " },
                {" ### ", "\n### " },
                {" * ", "\n* " },
                {"&quot;", "\"" },
                {"&amp;", "&" },
                {"</tr><tr>", "</tr>\n<tr>" },
                {"\"><tr>", "\">\n<tr>" },
                {"<table", "\n<table" },
                {"</table>", "\n</table>\n" },
                {"<markdown ngPreserveWhitespaces>", "\n<markdown ngPreserveWhitespaces>\n" },
                {"</markdown>", "\n</markdown>\n" },
                {"<ul>", "\n<ul>" },
                {"</ul>", "\n</ul>" },
                {"<li>", "\n<li>" },
                {"</p>", "</p>\n" },
                {"<p>", "\n<p>" }
        };


            foreach (KeyValuePair<string, string> r in rpls)
            {
                text = text.Replace(r.Key, r.Value);
            }
            return text;
        }

        void ParseMarkdown()
        {
            string md = "This is **Markdown**";
            MarkdownDocument document = new MarkdownDocument();
            document.Parse(md);

            // Takes note of all of the Top Level Headers.
            foreach (var element in document.Blocks)
            {
                Console.WriteLine(element.ToString());
                //if (element is HeaderBlock header)
                //{
                //    Console.WriteLine($"Header: {header.ToString()}");
                //}
            }
        }

        void RenderMarkdown()
        {
            var result = CommonMark.CommonMarkConverter.Convert("**Hello world!**");
        }

    }
}
