using System;
using System.IO;
using GM.GoogleCLoud;
using GM.Utilities;
using GM.ProcessRecording;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GM.ViewModels;
using Google.Protobuf.Collections;

namespace DevelopTranscription
{
    class Program
    {
        static void Main(string[] args)
        {
            string videofilePath = Path.Combine(GMFileAccess.GetClientAppFolder(), @"src\assets\stubdata\ToFix.mp4");
            string testdataFolder = Path.Combine(GMFileAccess.GetTestdataFolder(), "DevelopTranscription");
            string audiofilePath = Path.Combine(testdataFolder, "ToFix.flac");
            string objectName = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15_3min.flac";
            string responseFile = Path.Combine(testdataFolder, "ToFix.json");
            string googleCloudBucketName = "govmeeting-transcribe";

            RepeatedField<string> phrases = new RepeatedField<string> {
                "Denise Griffin",
                "Jay Warren",
                "Wendy Wolf",
                "Russell Hoffman",
                "William Hamblen",
                "Thomas Woodin",
                "Tom Woodin",
                "Kellie Bigos",
                "Julia Latter",
            };

            TranscribeParameters transParams = new TranscribeParameters
            {
                audiofilePath = audiofilePath,
                objectName = objectName,
                GoogleCloudBucketName = googleCloudBucketName,
                useAudioFileAlreadyInCloud = true,
                language = "en",
                MinSpeakerCount = 2,
                MaxSpeakerCount = 6,
                phrases = phrases
            };

            // Clean up from last run
            File.Delete(audiofilePath);
            File.Delete(responseFile);

            //string shortVideoFile = Path.Combine(testdataFolder, "ToFix - 4min.mp4");
            //SplitRecording splitRecording = new SplitRecording();
            //splitRecording.ExtractPart(videofilePath, shortVideoFile, 60, 3 * 60);

            string shortVideoFile = videofilePath;      // original is already only 3 min.
            ExtractAudio extract = new ExtractAudio();
            extract.Extract(shortVideoFile, audiofilePath);

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            TranscribeAudio transcribe = new TranscribeAudio();


            TranscribeResponse response = transcribe.MoveToCloudAndTranscribe(transParams);

            string transcript = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(responseFile, transcript);

            WriteResponseToTmp(transcript, testdataFolder);

            /////// Reformat the JSON transcript to match what the fixasr routine will use.

            //ModifyTranscriptJson convert = new ModifyTranscriptJson();
            //string outputJsonFile = Path.Combine(testdataFolder, "04-ToFix.json");
            //FixasrView fixasr = convert.Modify(transcript);
            //stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            //File.WriteAllText(outputJsonFile, stringValue);

        }

        // We write a new file for each run so we can compare improvements
        // in transcription. The files are:
        // c:\tmp\Response1.json, c:\tmp\Response2.json
        private static void WriteResponseToTmp(string transcript, string testdataFolder)
        {
            int x = 1;
            string next;
            do
            {
                next = Path.Combine(testdataFolder, $"Response{x++}.json");
            } while (File.Exists(next));

            string rawResponse = JsonConvert.SerializeObject(transcript, Formatting.Indented);
            File.WriteAllText(next, rawResponse);
        }

    }
}
