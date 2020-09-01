using System;
using System.IO;
using GM.GoogleCloud;
using GM.Utilities;
using GM.ProcessRecording;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GM.ViewModels;
using Google.Protobuf.Collections;
using Google.Cloud.Speech.V1P1Beta1;

/* This program is for experimenting with Google Speech-to-Text.
 *   * To transcribe samples.
 *   * To experiment with transcribe settings to get the most accurate result.
 *   * To examine the output and extract the most information.
 *   * To work on formatting the response in the best way for the routines that will handle it.
 */

namespace DevelopTranscription
{
    class Program
    {


        static void Main()
        {
            // audio extracted from video.
            string audioFile = AddPath("ToFix.flac");

            // response returned from TranscribeAudio.TranscribeAudioFile().
            // Transcribed, Simplified and Fixed.
            string transSimpFix = AddPath("transSimpFix.json");

            // the "raw response" - as returned from Google Cloud.
            string rawResponse = AddPath("rawResponse.json");

            // the "simplified response" - modification of raw response.
            string simplifiedResponse = AddPath("simplifiedResponse.json");

            // the "fixed response" - after the speaker tag property is fixed.
            string fixedResponse = AddPath("fixedResponse.json");

            // The response after it is converted to the json format expected by EditTranscript
            string toEdit = AddPath("ToEditTranscript.json");

            /*  We separate the steps needed so that we can work on each of them seperately.
             */

            int caseSwitch = 4;
            bool useSmallSample = false;

            // sample video files
            SampleVideos samples = new SampleVideos();

            switch (caseSwitch) {
                case 1: 
                    // Transcribe a sample video. This also simplifies the response and fixes the speaker tags.
                    TransscribeVideo(samples.LittleFallsVideo, transSimpFix, audioFile, useSmallSample, rawResponse);
                    break;
                case 2:
                    // Simplify the raw response
                    SimplifyRaw(rawResponse, simplifiedResponse);
                    break;
                case 3:
                    // Fix the speaker tags
                    FixSpeakerTags(simplifiedResponse, fixedResponse);
                    break;
                case 4:
                    // Convert the response to that expected by EditTranscript
                    CreateEditTranscriptView(fixedResponse, toEdit);
                    break;
                case 5:
                    // Transcribe, simplify, fix and convert to EditTranscriptView.
                    TransscribeVideo(samples.LittleFallsVideo, transSimpFix, audioFile, useSmallSample, rawResponse);
                    CreateEditTranscriptView(fixedResponse, toEdit);
                    break;
            }
        }

        static string AddPath(string name)
        {
            // our work folder
            string testdataFolder = Path.Combine(GMFileAccess.GetTestdataFolder(), "DevelopTranscription");
            return Path.Combine(testdataFolder, name);
        }

        static void TransscribeVideo(SampleVideo sample, string transSimpFix, string audioFile,
            bool useSmallSample, string rawResponse)
        {
            string videofilePath = sample.filepath;
            string objectName = sample.objectname;
            RepeatedField<string> phrases = sample.phrases;
            AudioProcessing audioProcessing = new AudioProcessing();

            string googleCloudBucketName = "govmeeting-transcribe";

            TranscribeParameters transParams = new TranscribeParameters
            {
                audiofilePath = audioFile,
                objectName = objectName,
                GoogleCloudBucketName = googleCloudBucketName,
                useAudioFileAlreadyInCloud = true,
                language = "en",
                MinSpeakerCount = 2,
                MaxSpeakerCount = 6,
                phrases = phrases
            };

            // Clean up from last run
            File.Delete(audioFile);
            File.Delete(transSimpFix);

            if (useSmallSample)
            {
                string shortVideoFile = videofilePath.Replace(".mp4", "-3min.mp4");
                //SplitRecording splitRecording = new SplitRecording();
                audioProcessing.ExtractPart(videofilePath, shortVideoFile, 60, 3 * 60);
                videofilePath = shortVideoFile;
            }

            audioProcessing.Extract(videofilePath, audioFile);

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            // Transcribe the audio file
            TranscribeAudio transcribe = new TranscribeAudio();
            TranscribeResult response = transcribe.TranscribeAudioFile(transParams, rawResponse);
            string responseString = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(transSimpFix, responseString);

            WriteCopyOfResponse(responseString, transSimpFix);
        }

        static void SimplifyRaw(string responseFile, string simplified)
        {
            // Clean up from last run
            File.Delete(simplified);

            string priorResponse = File.ReadAllText(responseFile);
            LongRunningRecognizeResponse beforeFix = JsonConvert.DeserializeObject<LongRunningRecognizeResponse>(priorResponse);
            TranscribeResult afterFix = TransformResponse.Simpify(beforeFix.Results);
            string afterFixString = JsonConvert.SerializeObject(afterFix, Formatting.Indented);
            File.WriteAllText(simplified, afterFixString);
        }

        static void FixSpeakerTags(string responseFile, string fixedRsp)
        {
            // Clean up from last run
            File.Delete(fixedRsp);

            string priorResponse = File.ReadAllText(responseFile);
            TranscribeResult beforeFix = JsonConvert.DeserializeObject<TranscribeResult>(priorResponse);
            TranscribeResult afterFix = TransformResponse.FixSpeakerTags(beforeFix);
            string afterFixString = JsonConvert.SerializeObject(afterFix, Formatting.Indented);
            File.WriteAllText(fixedRsp, afterFixString);
        }

        // Create the EditTranscriptView structure used by EditTranscript
        static void CreateEditTranscriptView(string responseFile, string editmeetingFile)
        {
            // Clean up from last run
            File.Delete(editmeetingFile);

            // Reformat the response to what the editmeeting routine will use.
            string responseString = File.ReadAllText(responseFile);
            TranscribeResult response = JsonConvert.DeserializeObject<TranscribeResult>(responseString);
            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            EdittranscriptView editmeeting = convert.Modify(response);
            string stringValue = JsonConvert.SerializeObject(editmeeting, Formatting.Indented);
            File.WriteAllText(editmeetingFile, stringValue);

        }

        // Write a new copy of the response file for each run so we can compare improvements
        // in transcription. The files are: Response1.json, Response2.json
        private static void WriteCopyOfResponse(string transcript, string transSimpFix)
        {
            int x = 1;
            string next;
            do
            {
                x++;
                next =  transSimpFix.Replace(".json", x.ToString() + ".json");
            } while (File.Exists(next));

            File.WriteAllText(next, transcript);
        }
    }
}
