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

            string testdataDirectory = currentDir + @"\..\..\..\..\testdata";

            processAutoTranscript.CreateJsonFile(
              testdataDirectory + @"\Step 0 - transcript from Youtube.txt",
              testdataDirectory + @"\output\Step 1 - json file.json"

            );
        }
    }
}
