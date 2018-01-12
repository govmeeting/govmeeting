using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace GM.ProcessRecordingLib
{

 /*
    This class is for converting the above format to JSON. This JSON file will then be input
    to the "fixasr" component within the ClientApp. The field "lastedit" will used to store the next starttime
    following the last edit that was made by fixasr. For example:

      {
      "lastedit": 0,
      "asrsegments": [
        {"startTime":"0:00","said":"the tuesday october 11 selectmen's"},
        {"startTime":"0:02","said":"meeting i will apologize apologize for"},
        {"startTime":"0:06","said":"my voice i can hardly speak i woke up"}
        ...
        ] }
 */

    public class CreateJsonFiles
    {

        public void CreateJsonFileAll(string inputFolder, string outputFolder)
        {
            Directory.CreateDirectory(outputFolder);
            foreach (string f in Directory.GetFiles(inputFolder, "*.txt"))
            {
                string name = Path.GetFileNameWithoutExtension(f);
                Console.WriteLine(f);

                CreateJsonFile(inputFolder + "\\" + name + ".txt", outputFolder + "\\" + name + ".json");
            }
        }
        public bool CreateJsonFile(string infile, string outfile)
        {
            string text = File.ReadAllText(infile);
            string jsontext = ConvertToJson(text);
            File.WriteAllText(outfile, jsontext);
            return true;
        }

        private string ConvertToJson(string text)
        {

            Phrase phrase = new Phrase { startTime = null, said = null };

            StringWriter strWriter = new StringWriter();
            strWriter.NewLine = "\n";

            StringReader strReader = new StringReader(text);
            string nextLine;
            bool firstRecord = true;

            string starttimeLabel = "startTime: ";
            int starttimeLabelLen = starttimeLabel.Length;

            string saidLabel = "Said: ";
            int saidLabelLen = saidLabel.Length;

            strWriter.WriteLine("{");
            strWriter.WriteLine("  \"lastedit\": 0,");
            strWriter.WriteLine("  \"asrsegments\": [");

            bool ReadFirstBlankLine = false;
            int linenum = 0;
            while ((nextLine = strReader.ReadLine()) != null)
            {
                linenum++;

                // if line is blank, ignore it.
                // If we haven't read the first blank line, throw away the line. The first non-blank lines
                // are heading info about the meeting.
                if (nextLine == "")
                {
                    ReadFirstBlankLine = true;
                    continue;
                }
                if (!ReadFirstBlankLine) continue;

                else if (CheckIfStartTime(nextLine))
                {
                    if (phrase.startTime != null)
                    {
                        Console.WriteLine("ERROR: Invalid input data (duplicate starttime) on line " + linenum);
                    };
                    phrase.startTime = nextLine;
                    continue;
                }
                else
                {
                    // Todo-g - check for invalid characters like a double quote.
                    if (phrase.said != null)
                    {
                        Console.WriteLine("ERROR: Invalid input data (duplicate said) on line " + linenum);
                    };
                    phrase.said = nextLine;
                }
                strWriter.Write(JsonRecord(ref phrase, ref strWriter, ref firstRecord));

                phrase.startTime = null;
                phrase.said = null;
            }
            strWriter.WriteLine("\n] }");
            return strWriter.ToString();
        }


        private bool CheckIfStartTime(string text)
        {
            // Start time is of the form "x:y:z" or "x:y" where x,y,z are numbers.
            // Examples are "04:13" and "01:04:13"
            string pattern1 = "^[0-9][0-9]?:[0-9][0-9]$";
            string pattern2 = "^[0-9][0-9]?:[0-9][0-9]:[0-9][0-9]$";
            string pattern = pattern1 + "|" + pattern2;
            string replacement = "";
            text = System.Text.RegularExpressions.Regex.Replace(text, pattern, replacement, System.Text.RegularExpressions.RegexOptions.Multiline);
            //text = Regex.Replace(text, pattern2, replacement, RegexOptions.Multiline);
            if (text == "") return true;
            return false;
        }

        private string JsonRecord(ref Phrase phrase, ref StringWriter writer, ref bool firstRecord)
        {
            string text = (firstRecord ? "" : ",\n") + "    " + Newtonsoft.Json.JsonConvert.SerializeObject(phrase);
            firstRecord = false;
            return text;
        }

    }
}