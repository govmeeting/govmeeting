using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using GM.Configuration;
using GM.ViewModels;
using GM.ProcessRecordings;

namespace GM.ProcessRecording
{
    public class RecordingProcess
    {
        /*     ProcessRecording processes new MP4 recording files that arrive.
         *     It performs the following steps:
         *       1. Extract the audio.
         *       2. Calls Google's Speech API to transcribe the text
         *       3. Convert the returned JSON data to a format more usable by the next processing step (Fixasr).
         *       4. Split the video, audio and text files into small segments. Each of these
         *          segments can then be worked on separately by multiple volunteers.
         */

        private readonly AppSettings _config;
        private readonly TranscribeAudio _transcribeAudio;

        public RecordingProcess(
            IOptions<AppSettings> config,
            TranscribeAudio transcribeAudio
            )
        {
            _config = config.Value;
            _transcribeAudio = transcribeAudio;
        }

        public void Process(string videoFile, string meetingFolder, string language)
        {
            /////// Copy video to meeting folder  /////////

            FileInfo infile = new FileInfo(videoFile);
            string videofileCopy = meetingFolder + "\\" + "R0-Video.mp4";

            if (!_config.IsDevelopment)
            {
                File.Copy(videoFile, videofileCopy);
            } else {
                // #### FOR DEVELOPMENT: WE SHORTEN THE RECORDING FILE. ####
                SplitRecording splitRecording = new SplitRecording();
                splitRecording.ExtractPart(videoFile, videofileCopy, 0, _config.RecordingSizeForDevelopment);
            }

            /////// Extract the audio. ////////////////////////

            ExtractAudio extract = new ExtractAudio();
            string audioFile = meetingFolder + "\\" + "R1-Audio.flac";
            extract.Extract(videofileCopy, audioFile);

            /////// Transcribe the audio file. /////////////

            // We want the object name in the cloud to be the original video file name with ".flac" extension.
            string objectName = Path.GetFileNameWithoutExtension(videoFile) + ".flac";
            //TranscribeAudio transcribe = new TranscribeAudio(language);

            TranscribeResponse transcript = _transcribeAudio.MoveToCloudAndTranscribe(audioFile, objectName, language);
            // For development and it's already in cloud
            //TranscribeResponse transcript = _transcribeAudio.TranscribeInCloud(objectName, language);

            string stringValue = JsonConvert.SerializeObject(transcript, Formatting.Indented);
            string outputJsonFile = meetingFolder + "\\" + "R2-Transcribed.json";
            File.WriteAllText(outputJsonFile, stringValue);

            /////// Reformat the JSON transcript to match what the fixasr routine will use.

            ModifyTranscriptJson convert = new ModifyTranscriptJson();
            outputJsonFile = meetingFolder + "\\" + "R3-ToBeFixed.json";
            FixasrView fixasr = convert.Modify(transcript);
            stringValue = JsonConvert.SerializeObject(fixasr, Formatting.Indented);
            File.WriteAllText(outputJsonFile, stringValue);

            /////// Split the video, audio and transcript into multiple work segments

            SplitIntoWorkSegments split = new SplitIntoWorkSegments();
            split.Split(meetingFolder, videofileCopy, outputJsonFile, _config.FixasrSegmentSize,
                _config.FixasrSegmentOverlap);
        }


    }
}
