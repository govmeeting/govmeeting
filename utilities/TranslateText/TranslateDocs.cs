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
        string folder = @"C:\GOVMEETING\_SOURCECODE\FrontEnd\ClientApp\src\assets\docs";

        public TranslateDocs(TranslateInCloud _translateInCloud)
        {
            translateInCloud = _translateInCloud;
        }

        public void Run(string[] args)
        {
            //string folder = args[1];
            //string language = args[2];

            List<string> languages = new List<string>()
                { "de", "es", "fr", "it", "fi", "ar", "sw", "zh", "pt" , "bn", "hi" };
                //{ "ic", "sw", "no" };

            foreach (string language in languages)
            {
                // Translate all the documents to all languages
                TranslateAllDocuments(language);

                // Translate just one specific document to all languages.
                // This is useful when edits are made to one document.
                string file = Path.Combine(folder, "overview1.en.md");
                TranslateOneDocument(file, language, true);
            };
        }


        public void TranslateAllDocuments(string language)
        {

            //ParseMarkdown();
            //RenderMarkdown();

            var files = from f in Directory.EnumerateFiles(folder)
                        where f.EndsWith(".en.md")
                        select f;

            foreach (string file in files)
            {
                TranslateOneDocument(file, language, false);
            }
        }

        private void TranslateOneDocument(string file, string language, bool deletePrior)
        {
            string newFile = file.Replace(".en.md", "." + language + ".md");

            if (File.Exists(newFile) && deletePrior)
            {
                File.Delete(newFile);
            }


            if (!File.Exists(newFile))
            {
                string contents = GMFileAccess.Readfile(file);
                var htmlContents = CommonMark.CommonMarkConverter.Convert(contents);
                //string htmlFile = f.Replace(".en.md", ".en.html");
                //File.WriteAllText(htmlFile, htmlContents);

                string translated = translateInCloud.TranslateHtml(htmlContents, language);
                //string htmlNewFile = f.Replace(".en.md", "." + language + ".html");
                //File.WriteAllText(htmlNewFile, translated);

                string replaced = ReplaceSomeStrings(translated);
                File.WriteAllText(newFile, replaced);

                // Wait 10 seconds. GCP didn't like me running a close loop.
                Task.Delay(10000).Wait();
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

        public void DoSomethingToAllFiles(string lang)
        {

            var files = from f in Directory.EnumerateFiles(folder)
                        where f.EndsWith("." + lang + ".md")
                        select f;
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine("ERROR: file does not exist: " + file);
                    continue;
                }

                string contents = GMFileAccess.Readfile(file);

                // Do something

            }
        }


    }
}
