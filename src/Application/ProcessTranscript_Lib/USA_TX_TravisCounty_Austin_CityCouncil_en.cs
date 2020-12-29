using System.IO;
using ProcessTranscript_Lib;

namespace GM.Application.ProcessTranscript
{
    class USA_TX_TravisCounty_Austin_CityCouncil_en : ISpecificFix
    {
        private string officersNames = "";
        private string meetingInfo = "";
        private string transcriptText = "";

        CommonFixes cf = new CommonFixes();
        LogProgress lp = new LogProgress();

        public string Fix(string _transcript, string workfolder)
        {
            lp.Initialize(meetingInfo, officersNames, workfolder);
            lp.Log("Start", _transcript);

            // 

            return transcriptText;
        }

    }
}
