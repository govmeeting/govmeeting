using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace GM.ProcessRecordingLib
{
    public class ExtractAudio
    {
        // Extract the audio from all files in the folder
        public void ExtractAll(string inputFolder, string outputFolder)
        {
            Directory.CreateDirectory(outputFolder);
            foreach (string f in Directory.GetFiles(inputFolder, "*.mp4"))
            {
                string name = Path.GetFileNameWithoutExtension(f);
                Console.WriteLine(f);

                Extract(inputFolder + "\\" + name + ".mp4", outputFolder + "\\" + name + ".flac");
            }
        }

        // Extract the audio from a file
        public void Extract(string inputFile, string outputFile)
        {
            RunCommand runCommand = new RunCommand();

            string inputFileQuoted = "\"" + inputFile + "\"";
            string outputFileQuoted = "\"" + outputFile + "\"";

            string command = "ffmpeg -i " + inputFileQuoted + " -ab 192000 -vn " + outputFileQuoted + " 2>&1";
            runCommand.ExecuteCmd(command);
        }
    }
}
