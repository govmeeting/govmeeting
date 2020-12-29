using System;
using System.IO;
using GM.Infrastructure.GoogleCloud;
using GM.Utilities;
using GM.Application.ProcessRecording;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Google.Protobuf.Collections;
using Google.Cloud.Speech.V1P1Beta1;
using Google.Protobuf;
using GM.Application.DTOs.Meetings;

//using GM.Application.ApplicationCore.DTOs;

/* This program is for experimenting with Google Speech-to-Text.
 *   * To transcribe samples.
 *   * To experiment with transcribe settings to get the most accurate result.
 *   * To examine the output and extract the most information.
 *   * To work on formatting the response in the best way for the routines that will handle it.
 */

namespace GM.Utilities.DevelopTranscription
{
    class Program
    {
        /*  We separate the steps needed so that we can work on each of them seperately.
           */

        enum JobType
        {
            TransSimpFixDto,    // Extract audio, transcribe, simplify raw, fix speaker tags & create EditMeetingDto
            TransSimpFix,       // extract audio, transcribe, simplify raw & fix speaker tags
            Trans,              // only transcribe the audio flac file
            Simp,               // only simplify the raw transcibed file
            Fix,                // only fix the speaker tag of the simplified file
            Dto                 // only create the EditMeetingDto from the fixed file
        }
        static void Main()
        {
            SampleVideos samples = new SampleVideos();

            string FlacAudio = AddPath("1_Audio.flac");         // step 1 flac audio file
            string RawTrans = AddPath("2_Trans.json");         // step 2 raw transcription
            string Simplified = AddPath("3_Simpify.json");        // step 3 simplified transcription
            string FixedTags = AddPath("4_Fix.json");           // step 4 SpeakerTags added
            string EditMeetingDto = AddPath("5_Dto.json");      // step 5 EditMeetingDto

            JobType JOB_TO_DO = JobType.Dto;
            SampleVideo SAMPLE_TO_USE = samples.LittleFallsVideo;
            bool USE_SMALL_SAMPLE = false;      // if true, use a small sample of video - 3 minutes
            bool USE_CLOUD_FILE = true;         // if true, use prior audio file in cloud if it exists

            switch (JOB_TO_DO) {
                case JobType.TransSimpFixDto:
                    // do steps 1, 2, 3, 4 & 5
                    TranscribeVideo(SAMPLE_TO_USE, FixedTags, FlacAudio, USE_SMALL_SAMPLE, USE_CLOUD_FILE, RawTrans);
                    CreateEditTranscriptView(FixedTags, EditMeetingDto);
                    break;

                case JobType.TransSimpFix:
                    // do steps 1, 2, 3 & 4 
                    TranscribeVideo(SAMPLE_TO_USE, FixedTags, FlacAudio, USE_SMALL_SAMPLE, USE_CLOUD_FILE, RawTrans);
                    break;

                case JobType.Simp:
                    // Simplify the raw transcription
                    SimplifyRaw(RawTrans, Simplified);
                    break;

                case JobType.Fix:
                    // Fix the simplified file by adding the speaker tags
                    FixSpeakerTags(Simplified, FixedTags);
                    break;

                case JobType.Dto:
                    // Convert Fixed to the MeetingEditDto
                    CreateEditTranscriptView(FixedTags, EditMeetingDto);
                    break;
            }
        }

        static string AddPath(string name)
        {
            // our work folder
            string testdataFolder = Path.Combine(GMFileAccess.GetTestdataFolder(), "DevelopTranscription");
            return Path.Combine(testdataFolder, name);
        }

        static void TranscribeVideo(
            SampleVideo sample,         // sample video to use
            string fixedTags,        // file in which to save the fixed transcription
            string audio,           // file in which to save the extracted audio
            bool useSmallSample,        // if true, use a small sample of the video/audio
            bool useAudioFileAlreadyInCloud,  // if true, use prior audio in cloud if it exists
            string rawTranscription)         // file in which to save the raw transcription
        {
            string videofilePath = sample.filepath;
            string objectName = sample.objectname;
            RepeatedField<string> phrases = sample.phrases;
            AudioProcessing audioProcessing = new AudioProcessing();

            string googleCloudBucketName = "govmeeting-transcribe";

            TranscribeParameters transParams = new TranscribeParameters
            {
                audiofilePath = audio,
                objectName = objectName,
                GoogleCloudBucketName = googleCloudBucketName,
                useAudioFileAlreadyInCloud = useAudioFileAlreadyInCloud,
                language = "en",
                MinSpeakerCount = 2,
                MaxSpeakerCount = 6,
                phrases = phrases
            };

            // Clean up from last run
            File.Delete(audio);
            File.Delete(fixedTags);

            if (useSmallSample)
            {
                string shortVideoFile = videofilePath.Replace(".mp4", "-3min.mp4");
                //SplitRecording splitRecording = new SplitRecording();
                audioProcessing.ExtractPart(videofilePath, shortVideoFile, 60, 3 * 60);
                videofilePath = shortVideoFile;
            }

            audioProcessing.Extract(videofilePath, audio);

            GMFileAccess.SetGoogleCredentialsEnvironmentVariable();

            // Transcribe the audio file
            TranscribeAudio transcribe = new TranscribeAudio();
            TranscribedDto response = transcribe.TranscribeAudioFile(transParams, rawTranscription);
            string responseString = JsonConvert.SerializeObject(response, Formatting.Indented);
            File.WriteAllText(fixedTags, responseString);

            WriteCopyOfResponse(responseString, fixedTags);
        }

        static void SimplifyRaw(string responseFile, string simplified)
        {
            // Clean up from last run
            File.Delete(simplified);

            string priorResponse = File.ReadAllText(responseFile);
            LongRunningRecognizeResponse beforeFix = JsonConvert.DeserializeObject<LongRunningRecognizeResponse>(priorResponse);
            TranscribedDto afterFix = TransformResponse.Simpify(beforeFix.Results);
            string afterFixString = JsonConvert.SerializeObject(afterFix, Formatting.Indented);
            File.WriteAllText(simplified, afterFixString);
        }

        static void FixSpeakerTags(string responseFile, string fixedRsp)
        {
            // Clean up from last run
            File.Delete(fixedRsp);

            string priorResponse = File.ReadAllText(responseFile);
            TranscribedDto beforeFix = JsonConvert.DeserializeObject<TranscribedDto>(priorResponse);
            TranscribedDto afterFix = TransformResponse.FixSpeakerTags(beforeFix);
            string afterFixString = JsonConvert.SerializeObject(afterFix, Formatting.Indented);
            File.WriteAllText(fixedRsp, afterFixString);
        }

        // Create the EditTranscriptView structure used by EditTranscript
        static void CreateEditTranscriptView(string fixedTags, string editmeetingFile)
        {
            // Clean up from last run
            File.Delete(editmeetingFile);

            // Reformat the response to what the editmeeting routine will use.
            string responseString = File.ReadAllText(fixedTags);
            TranscribedDto response = JsonConvert.DeserializeObject<TranscribedDto>(responseString);
            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            EditMeetingDto editmeeting = convert.Modify(response);
            string stringValue = JsonConvert.SerializeObject(editmeeting, Formatting.Indented);
            File.WriteAllText(editmeetingFile, stringValue);

        }

        // Write a new copy of the response file for each run so we can compare improvements
        // in transcription. The files are: Response1.json, Response2.json
        private static void WriteCopyOfResponse(string transcript, string fixedTags)
        {
            int x = 1;
            string next;
            do
            {
                x++;
                next =  fixedTags.Replace(".json", x.ToString() + ".json");
            } while (File.Exists(next));

            File.WriteAllText(next, transcript);
        }
    }
}
