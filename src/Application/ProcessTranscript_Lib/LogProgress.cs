using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProcessTranscript_Lib
{
    class LogProgress
    {
        string officersNames;
        string meetingInfo;
        string workfolder;

        int step = 1;

        public void Initialize(string info, string names, string work)
        {
            meetingInfo = info;
            officersNames = names;
            workfolder = work;
        }

        public void Log(string fix_step, string transcriptText)
        {
            string outputFile = Path.Combine(workfolder, "2-" + step + " " + fix_step + ".txt");
            step++;

            File.WriteAllText(outputFile, meetingInfo + "-----------------------------\n" + officersNames + "-----------------------------\n" + transcriptText);
        }
    }
}
