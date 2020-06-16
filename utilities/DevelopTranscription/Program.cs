using System;
using System.IO;
using GM.GoogleCloud;
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
        static string testdataFolder = Path.Combine(GMFileAccess.GetTestdataFolder(), "DevelopTranscription");
        static string responseFile = Path.Combine(testdataFolder, "response.json");
        static string newResponseFile = Path.Combine(testdataFolder, "newResponse.json");
        static string editmeetingFile = Path.Combine(testdataFolder, "ToEditTranscript.json");


        static void Main(string[] args)
        {
            int caseSwitch = 1;

            switch (caseSwitch) {
                case 1: 
                    TransscribeVideo();
                    break;
                case 2:
                    FixSpeakerTags(responseFile, newResponseFile);
                    break;
                case 3:
                    CreateEditTranscriptView(newResponseFile, editmeetingFile);
                    break;
            }
        }

        static void TransscribeVideo()
        {
            string videofilePath = Path.Combine(GMFileAccess.GetClientAppFolder(), @"src\assets\stubdata\ToFix.mp4");
            string audiofilePath = Path.Combine(testdataFolder, "ToFix.flac");
            string googleCloudBucketName = "govmeeting-transcribe";
            string objectName = "USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en_2017-02-15_3min.flac";

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

            // Transcribe the audio file
            TranscribeAudio transcribe = new TranscribeAudio();
            TranscribeResponse response = transcribe.TranscribeAudioFile(transParams);
            string responseString = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(responseFile, responseString);

            // Reformat the JSON transcript to match what the editmeeting routine will use.
            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            EdittranscriptView editmeeting = convert.Modify(response);
            string stringValue = JsonConvert.SerializeObject(editmeeting, Formatting.Indented);
            File.WriteAllText(editmeetingFile, stringValue);

            WriteCopyOfResponse(responseString, testdataFolder);
        }

        // Write a new copy of the response file for each run so we can compare improvements
        // in transcription. The files are: Response1.json, Response2.json
        private static void WriteCopyOfResponse(string transcript, string testdataFolder)
        {
            int x = 1;
            string next;
            do
            {
                next = Path.Combine(testdataFolder, $"Response{x++}.json");
            } while (File.Exists(next));

            File.WriteAllText(next, transcript);
        }

        static void FixSpeakerTags(string responseFile, string newResponseFile)
        {
            string priorResponse = File.ReadAllText(responseFile);
            TranscribeResponse beforeFix = JsonConvert.DeserializeObject<TranscribeResponse>(priorResponse);
            TranscribeResponse afterFix = TransformResponse.FixSpeakerTags(beforeFix);
            string afterFixString = JsonConvert.SerializeObject(afterFix, Formatting.Indented);
            File.WriteAllText(newResponseFile, afterFixString);
        }

        // Create the EditTranscriptView structure used by EditTranscript
        static void CreateEditTranscriptView(string responseFile, string editmeetingFile)
        {
            // Reformat the response to what the editmeeting routine will use.
            string responseString = File.ReadAllText(responseFile);
            TranscribeResponse response = JsonConvert.DeserializeObject<TranscribeResponse>(responseString);
            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            EdittranscriptView editmeeting = convert.Modify(response);
            string stringValue = JsonConvert.SerializeObject(editmeeting, Formatting.Indented);
            File.WriteAllText(editmeetingFile, stringValue);

        }

    }
}
