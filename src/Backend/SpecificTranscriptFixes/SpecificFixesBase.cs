using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace GM.SpecificTranscriptFixes
{
    public class SpecificFixesBase
    {
        protected string officersNames = "";
        protected string meetingInfo = "";
        protected string transcript = "";
        protected string meetingDate;
        protected string logDirectory;

        int step = 1;

        public SpecificFixesBase(string _meetingDate, string _logDirectory)
        {
            meetingDate = _meetingDate;
            logDirectory = _logDirectory;
        }

        protected void LOGPROGRESS(string fix_step)
        {
            string outputFile = logDirectory + "\\" + "step" + step + "_" + fix_step + ".txt";
            step++;

            File.WriteAllText(outputFile, meetingInfo + "-----------------------------\n" + officersNames + "-----------------------------\n" + transcript);
        }

        protected DateTime GetMeetingDatetime()
        {
            // https://blog.nicholasrogoff.com/2012/05/05/c-datetime-tostring-formats-quick-reference/
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            DateTime dateTime = DateTime.ParseExact(meetingDate, "yyyy-MM-dd", MyCultureInfo);
            return dateTime;
        }

    }
}
