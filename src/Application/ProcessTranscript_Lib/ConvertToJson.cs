using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GM.Application.ProcessTranscript
{
    public static class ConvertToJson
    {
        public static void Convert(ref string text)
        {

            Talk talk = new Talk { speaker = null, said = null, section = null, topic = null, showSetTopic = false };

            StringWriter strWriter = new StringWriter();
            strWriter.NewLine = "\n";

            StringWriter said = new StringWriter();
            said.NewLine = "\n";

            StringReader strReader = new StringReader(text);
            string nextLine;
            bool firstRecord = true;

            string sectionLabel = "Section: ";
            int sectionLabelLen = sectionLabel.Length;
            string speakerLabel = "Speaker: ";
            int speakerLabelLen = speakerLabel.Length;

            strWriter.WriteLine("{ \"data\": [");

            while ((nextLine = strReader.ReadLine()) != null)
            {
                // if line is blank, ignore it.
                if (nextLine == "")
                {
                }
                // If line is section name, store it.
                else if ((nextLine.Length >= sectionLabelLen) && (nextLine.Substring(0, sectionLabelLen) == sectionLabel))
                {
                    if (talk.speaker != null)
                    {
                        strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
                    }
                    // ignore blank lines after Section: line.
                    talk.section = nextLine.Substring(sectionLabelLen);
                }
                // if line is speaker name, store it.
                else if ((nextLine.Length >= speakerLabelLen) && (nextLine.Substring(0, speakerLabelLen) == speakerLabel))
                {
                    if (talk.speaker != null)
                    {
                        strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
                    }
                    talk.speaker = nextLine.Substring(speakerLabelLen);

                }
                // If it is something else and we have a current speaker, it is what was said.
                else if (talk.speaker != null)
                {
                    said.WriteLine(nextLine);
                }
            }
            if (talk.speaker != null)
            {
                strWriter.WriteLine(JsonRecord(ref talk, ref said, ref firstRecord));
            }
            strWriter.WriteLine("\n] }");
            text = strWriter.ToString();
        }

        static string JsonRecord(ref Talk talk, ref StringWriter said, ref bool firstRecord)
        {
            talk.said = said.ToString();

            string text = (firstRecord ? "" : ",") + "\n    " + Newtonsoft.Json.JsonConvert.SerializeObject(talk);
            firstRecord = false;

            talk.speaker = null;
            talk.section = null;
            talk.said = null;
            talk.topic = null;
            talk.showSetTopic = false;
            said.Dispose();
            said = new StringWriter();
            said.NewLine = "\n";
            return text;
        }

    }
}
