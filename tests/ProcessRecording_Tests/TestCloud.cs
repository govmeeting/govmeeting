using GM.Application.Configuration;
using GM.Application.DTOs.Meetings;
using GM.Application.ProcessRecording;
using GM.Infrastructure.GoogleCloud;
using GM.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;

namespace GM.Tests.ProcessRecording_Tests

{
    public class TestCloud
    {
        private readonly string language = "en";
        private readonly AppSettings config;
        readonly TranscribeAudio transcribe;

        public TestCloud(
            IOptions<AppSettings> _config,
            TranscribeAudio _transcribe
        )
        {
            config = _config.Value;
            transcribe = _transcribe;
        }

        public void TestAll()
        {
            TestMoveToCloudAndTranscribe(language);
            TestTranscriptionOfFileInCloud(language);
            TestTranscriptionOfLocalFile(language);
        }

        public void TestMoveToCloudAndTranscribe(string language)
        {
            AudioProcessing audioProcessing = new AudioProcessing();

            string baseName = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-02-15";
            string videoFile = Path.Combine(config.TestdataPath, baseName + ".mp4");
            string outputFolder = Path.Combine(config.TestdataPath, "TestMoveToCloudAndTranscribe");

            GMFileAccess.DeleteAndCreateDirectory(outputFolder);

            string outputBasePath = Path.Combine(outputFolder, baseName);
            string shortFile = outputBasePath + ".mp4";
            string audioFile = outputBasePath + ".flac";
            string jsonFile = outputBasePath + ".json";


            // Extract short version
            //SplitRecording splitRecording = new SplitRecording();
            audioProcessing.ExtractPart(videoFile, shortFile, 60, 4 * 60);

            // Extract audio.
            audioProcessing.Extract(shortFile, audioFile);

            // Transcribe
            //TranscribeAudio ta = new TranscribeAudio(_config);

            //TranscribeResultOrig response = new TranscribeResultOrig();
            TranscribedDto response = new TranscribedDto();

            // TODO - signature of TranscribeInCloud has changed.
            // response = transcribe.MoveToCloudAndTranscribe(audioFile, baseName + ".flac", config.GoogleCloudBucketName, config.UseAudioFileAlreadyInCloud, language);

            string stringValue = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(outputBasePath + "-rsp.json", stringValue);

            // Modify Transcript json format
            //ModifyTranscriptJson_1 mt = new ModifyTranscriptJson_1();
            ModifyTranscriptJson mt = new ModifyTranscriptJson();
            //FixasrViewModel fixasr = mt.Modify(response);
            EditMeetingDto meetingEditDto = mt.Modify(response);

            // Create JSON file
            //stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            stringValue = JsonConvert.SerializeObject(meetingEditDto, Formatting.Indented);
            File.WriteAllText(jsonFile, stringValue);
        }

        public void TestTranscriptionOfFileInCloud(string language)
        {
            //TranscribeAudio ta = new TranscribeAudio(_config);

            // Test transcription of a file already in the cloud storage bucket

            TranscribeResultOrig transcript = new TranscribeResultOrig();

            // TODO - signature of TranscribeInCloud has changed.
            // transcript = transcribe.TranscribeInCloud("USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-01-09_00-01-40.flac", language);
            //TranscribeResponse transcript = ta.TranscribeInCloud("Step 0 original#00-06-40.flac", language);

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
        }

        public void TestTranscriptionOfLocalFile(string language)
        {
            //TranscribeAudio ta = new TranscribeAudio(_config);

            // Test transcription on a local file. We will use sychronous calls to the Google Speech API. These allow a max of 1 minute per request.
            string folder = config.TestdataPath + @"..\testdata\BBH Selectmen\USA_ME_LincolnCounty_BoothbayHarbor_Selectmen\2017-01-09\step 2 extract\";
            //TranscribeResultOrig transcript = transcribe.TranscribeFile(folder + "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-01-09#00-01-40.flac", language);
            TranscribedDto transcript = transcribe.TranscribeLocalFile(folder + "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_EN_2017-01-09#00-01-40.flac", language);

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
        }
    }
}
