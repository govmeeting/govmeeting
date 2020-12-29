using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using GM.Application.Configuration;
using GM.Infrastructure.GoogleCloud;
using GM.Utilities;
using GM.Application.DTOs.Meetings;

namespace GM.Application.ProcessRecording
{
    public interface IRecordingProcess
    {
        public void Process(string videoFile, string meetingFolder, string language);
    }


    public class RecordingProcess : IRecordingProcess
    {
        /*     ProcessRecording processes new MP4 recording files that arrive.
         *     It performs the following steps:
         *       1. Extract the audio.
         *       2. Calls Google's Speech API to transcribe the text
         *       3. Convert the returned JSON data to a format more usable by the next processing step (EditTranscript).
         *       4. Split the video, audio and text files into small segments. Each of these
         *          segments can then be worked on separately by multiple volunteers.
         */

        private readonly AppSettings config;
        private readonly TranscribeAudio transcribeAudio;

        public RecordingProcess(
            IOptions<AppSettings> _config,
            TranscribeAudio _transcribeAudio
            )
        {
            config = _config.Value;
            transcribeAudio = _transcribeAudio;
        }

        public void Process(string videoFile, string meetingFolder, string language)
        {
            /////// Copy video to meeting folder  /////////

            AudioProcessing audioProcessing = new AudioProcessing();
            string videofileCopy = Path.Combine(meetingFolder,"video.mp4");

            // #### If MaxRecordingSize is not zero, we shorted the recording. ####
            if (config.MaxRecordingSize == 0)
            {
                File.Copy(videoFile, videofileCopy);
            }
            else
            {
                audioProcessing.ExtractPart(videoFile, videofileCopy, 0, config.MaxRecordingSize);
            }

            /////// Extract the audio. ////////////////////////

            ExtractAudio extract = new ExtractAudio();
            string audioFile = Path.Combine(meetingFolder,"audio.flac");
            audioProcessing.Extract(videofileCopy, audioFile);

            /////// Transcribe the audio file. /////////////

            // We want the object name in the cloud to be the original video file name with ".flac" extension.
            string objectName = Path.GetFileNameWithoutExtension(videoFile) + ".flac";

            TranscribeParameters transParams = new TranscribeParameters
            {
                audiofilePath = audioFile,
                objectName = objectName,
                GoogleCloudBucketName = config.GoogleCloudBucketName,
                useAudioFileAlreadyInCloud = config.UseAudioFileAlreadyInCloud,
                language = language,
                MinSpeakerCount = 2,
                MaxSpeakerCount = 6
                // TODO Add "phrases" field: names of officers
            };

            TranscribedDto transcript = transcribeAudio.TranscribeAudioFile(transParams);

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
            string outputJsonFile = Path.Combine(meetingFolder, "transcribed.json");
            File.WriteAllText(outputJsonFile, stringValue);
        }

    }
}
