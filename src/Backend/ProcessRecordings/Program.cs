using System;
using System.IO;
using GM.ProcessRecordingLib;

namespace GM.ProcessRecordings
{
    class Program
    {
        static void Main(string[] args)
        {
            string incomingRecordings = Environment.CurrentDirectory + @"..\..\Datafiles\IN PROCESS";
            string testDataFolder = Environment.CurrentDirectory + "\\testdata";

            string filename = "2016-10-11 USA_ME_LincolnCounty_BoothbayHarbor_Selectmen.mp4";
            string inputFile = incomingRecordings + "\\" + filename;

            ProcessRecording processRec = new ProcessRecording();
            processRec.Process(inputFile, testDataFolder);
        }
    }
}
