using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace GM.ProcessTranscript
{
    public static class ConvertPdfToText
    {
        /*
         * Convert a PDF file to a text by extracting just the text.
        */
        public static string Convert(string infile)
        {
            StringBuilder strPdfContent = new StringBuilder();

            PdfReader reader = new PdfReader(infile);

            /*
             * This conversion code is thanks to the developers of iTextSharp and asturcon at
             * http://www.codeproject.com/Questions/770857/Convert-PDF-tp-text-formatted-using-iTextSharp-csh 
             * Before this was used, manual conversion was done with Adobe Acrobat or Microsoft Word.
             * They both convert very badly - missing spaces, linefeeds, reversed lines, etc. Their problems appear
             * to be related to how they handle default character encoding on Windows. For an explanation, see:
             * https://www.informit.com/guides/content.aspx?g=dotnet&seqNum=163
             */
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                ITextExtractionStrategy objExtractStrategy = new SimpleTextExtractionStrategy();
                string strLineText = PdfTextExtractor.GetTextFromPage(reader, i, objExtractStrategy);
                strLineText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(strLineText)));

                strPdfContent.Append(strLineText);
                strPdfContent.Append("\n");
            }
            reader.Close();
            string text = strPdfContent.ToString();
            return text;
        }
    }
}
