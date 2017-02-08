using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateJsonFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProcessAutoTranscript processAutoTranscript = new ProcessAutoTranscript();

            string currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            string DataDirectory = currentDir + @"\..\..\..\..\..\..\Server\WebApp\wwwroot\assets\data";
            string meetingDirectory = DataDirectory + "\\" + @"USA_ME_LincolnCounty_BoothbayHarbor_Selectmen\2016-10-11";

            processAutoTranscript.CreateJsonFile(
              meetingDirectory + @"\Step 1 - transcript from Youtube.txt",
              meetingDirectory + @"\Step 2 - convert Youtube text to JSON.json"

            );

            // Copy the output file to WebApp/wwwroot/assets
            string srcDirectory = currentDir + @"\..\..\..\..\..";
            string assetsDirectory = srcDirectory + @"Server\wwwroot\assets";
        }
    }
}
