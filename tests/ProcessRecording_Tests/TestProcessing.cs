using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

using GM.Application.ProcessRecording;
using GM.Infrastructure.GoogleCloud;
using GM.Application.Configuration;
using GM.Utilities;
using GM.Application.EditTranscript;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.DTOs.Meetings;

namespace GM.Tests.ProcessRecording_Tests
{
    public class TestProcessing
    {
        readonly AppSettings _config;

        private readonly string testfilesPath;
        // private string datafilesPath;

        public TestProcessing(IOptions<AppSettings> config)
        {
            _config = config.Value;
            testfilesPath = Environment.CurrentDirectory + _config.TestdataPath;
            // datafilesPath = Environment.CurrentDirectory + _config.DatafilesPath;
        }

        public void TestAll()
        {
            TestReformatOfTranscribeResponse();
            TestSplitIntoWorkSegments();
            TestSplitTranscript();
        }

        public void TestSplitTranscript()
        {
            string fixasrFile = @"C:\GOVMEETING\_SOURCECODE\src\DATAFILES\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-02-15\R3-ToBeFixed.json";
            string stringValue = File.ReadAllText(fixasrFile);
            EditMeeting_Dto meetingEditDto = JsonConvert.DeserializeObject<EditMeeting_Dto>(stringValue);
            string outputFolder = @"C:\GOVMEETING\_SOURCECODE\src\DATAFILES\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en\2017-02-15\FixText";
            int sectionSize = 180;
            int overlap = 5;
            int parts = 4;

            SplitTranscript st = new SplitTranscript();
            st.Split(meetingEditDto, outputFolder, sectionSize, overlap, parts);

        }
        public void TestSplitIntoWorkSegments()
        {

            //string videoFile = testdata + @"\TestMoveToCloudAndTranscribe - Copy\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15.mp4";
            //string transcriptFile = testdata + @"\TestMoveToCloudAndTranscribe - Copy\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15.json";

            //string outputFolder = Path.Combine(testdata, "TestSplitIntoWorkSegments");
            //DeleteAndCreateDirectory(outputFolder);

            string outputFolder = @"C:\GOVMEETING\_SOURCECODE\src\DATAFILES\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN\2017-01-09";
            string videoFile = Path.Combine(outputFolder, "01-Video.mp4");
            string transcriptFile = Path.Combine(outputFolder, "R3-ToBeFixed.json");
            int segmentSize = 180;
            int overlap = 5;

            WorkSegments split = new WorkSegments();
            split.Split(outputFolder, videoFile, transcriptFile, segmentSize, overlap);
        }

        public void TestReformatOfTranscribeResponse()
        {
            string inputFile = testfilesPath + @"\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15-rsp.json";

            string outputFolder = Path.Combine(testfilesPath, "TestReformatOfTranscribeResponse");
            GMFileAccess.DeleteAndCreateDirectory(outputFolder);
            string outputFile = outputFolder + @"\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15.json";

            string stringValue = File.ReadAllText(inputFile);
            var transcript = JsonConvert.DeserializeObject<Transcribed_Dto>(stringValue);

            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            EditMeeting_Dto meetingEditDto = convert.Modify(transcript);

            stringValue = JsonConvert.SerializeObject(meetingEditDto, Formatting.Indented);
            File.WriteAllText(outputFile, stringValue);
        }
    }
}
