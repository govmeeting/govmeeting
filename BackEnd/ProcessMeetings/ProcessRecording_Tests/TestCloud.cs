using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

using GM.ProcessRecording;
using GM.ViewModels;
using GM.Configuration;
using GM.GoogleCLoud;

namespace GM.ProcessRecording_Tests

{
    public class TestCloud
    {
        private string language = "en";
        private AppSettings _config;

        TranscribeAudio transcribe;

        public TestCloud(
            IOptions<AppSettings> config,
            TranscribeAudio _transcribe
        )
        {
            _config = config.Value;
            transcribe = _transcribe;
        }

        public void TestAll()
        {
            //_config.DatafilesPath = Environment.CurrentDirectory + @"\..\..\Datafiles";
            //_config.TestfilesPath = Environment.CurrentDirectory + @"\..\..\testdata";
            _config.DatafilesPath = Environment.CurrentDirectory + _config.DatafilesPath;
            _config.TestfilesPath = Environment.CurrentDirectory + _config.TestfilesPath;
            _config.GoogleApplicationCredentials = Environment.CurrentDirectory + @"..\\..\\..\\..\\..\\..\\..\\..\\_SECRETS\\TranscribeAudio.json";

            TestMoveToCloudAndTranscribe(language);
            TestTranscriptionOfFileInCloud(language);
            TestTranscriptionOfLocalFile(language);
        }

        public void TestMoveToCloudAndTranscribe(string language)
        {
            string baseName = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15";
            string videoFile = _config.TestfilesPath + "\\" + baseName + ".mp4";
            string outputFolder = _config.TestfilesPath + "\\" + "TestMoveToCloudAndTranscribe";

            FileDataRepositories.GMFileAccess.DeleteAndCreateDirectory(outputFolder);

            string outputBasePath = outputFolder + "\\" + baseName;
            string shortFile = outputBasePath + ".mp4";
            string audioFile = outputBasePath + ".flac";
            string jsonFile = outputBasePath + ".json";


            // Extract short version
            SplitRecording splitRecording = new SplitRecording();
            splitRecording.ExtractPart(videoFile, shortFile, 60, 4 * 60);

            // Extract audio.
            ExtractAudio extract = new ExtractAudio();
            extract.Extract(shortFile, audioFile);

            // Transcribe
            //TranscribeAudio ta = new TranscribeAudio(_config);
            TranscribeResponse response = transcribe.MoveToCloudAndTranscribe(audioFile, baseName + ".flac", language);

            string stringValue = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(outputBasePath + "-rsp.json", stringValue);

            // Modify Transcript json format
            ModifyTranscriptJson mt = new ModifyTranscriptJson();
            FixasrView fixasr = mt.Modify(response);

            // Create JSON file
            stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            File.WriteAllText(jsonFile, stringValue);
        }

        public void TestTranscriptionOfFileInCloud(string language)
        {
            //TranscribeAudio ta = new TranscribeAudio(_config);

            // Test transcription of a file already in the cloud storage bucket
            TranscribeResponse transcript = transcribe.TranscribeInCloud("USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-01-09_00-01-40.flac", "en");
            //TranscribeResponse transcript = ta.TranscribeInCloud("Step 0 original#00-06-40.flac", "en");

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
        }

        public void TestTranscriptionOfLocalFile(string language)
        {
            //TranscribeAudio ta = new TranscribeAudio(_config);

            // Test transcription on a local file. We will use sychronous calls to the Google Speech API. These allow a max of 1 minute per request.
            string folder = _config.TestfilesPath + @"..\testdata\BBH Selectmen\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen\2017-01-09\step 2 extract\";
            TranscribeResponse transcript = transcribe.TranscribeFile(folder + "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-01-09#00-01-40.flac", language);

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
        }
    }
}
