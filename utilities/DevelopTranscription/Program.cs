using System;
using System.IO;
using GM.GoogleCLoud;
using GM.Utilities;
using GM.ProcessRecording;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GM.ViewModels;

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
            string language = "en";
            string responseFile = Path.Combine(testdataFolder, "ToFix.json");

            string googleCloudBucketName = "govmeeting-transcribe";
            bool useAudioFileAlreadyInCloud = true;

            //string shortVideoFile = Path.Combine(testdataFolder, "ToFix - 4min.mp4");
            //SplitRecording splitRecording = new SplitRecording();
            //splitRecording.ExtractPart(videofilePath, shortVideoFile, 60, 3 * 60);

            string shortVideoFile = videofilePath;      // original is already only 3 min.
            ExtractAudio extract = new ExtractAudio();
            extract.Extract(shortVideoFile, audiofilePath);

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            TranscribeAudio transcribe = new TranscribeAudio();

            TranscribeResponse response = transcribe.MoveToCloudAndTranscribe(audiofilePath, objectName, googleCloudBucketName,
                useAudioFileAlreadyInCloud, language);

            string transcript = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(responseFile, transcript);

            /////// Reformat the JSON transcript to match what the fixasr routine will use.

            //ModifyTranscriptJson convert = new ModifyTranscriptJson();
            //string outputJsonFile = Path.Combine(testdataFolder, "04-ToFix.json");
            //FixasrView fixasr = convert.Modify(transcript);
            //stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            //File.WriteAllText(outputJsonFile, stringValue);

        }
    }
}
