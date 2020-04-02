using System.IO;
using ProcessTranscript_Lib;

namespace GM.ProcessTranscript
{
    class Specific_Austin_TX_USA : ISpecificFix
    {
        private string transcriptText;
        private string officersNames = "";
        private string meetingInfo = "";
        CommonFixes cf = new CommonFixes();
        LogProgress lp;

        public Specific_Austin_TX_USA(string logDirectory)
        {
            lp = new LogProgress(logDirectory);
        }

        public string Fix(string _transcript)
        {
            lp.Log("Start", _transcript);

            return _transcript;
        }

    }
}
