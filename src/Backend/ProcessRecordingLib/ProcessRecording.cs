using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ProcessRecordingLib
{
    public class ProcessRecording
    {
        public void Process(string inputFile, string outputFolder)
        {
            // Split the recording into 3 minute segments and put them in subfolder "split".
            SplitRecording split = new SplitRecording();
            string splitFolder = outputFolder + "\\" + "step 1 split";
            split.Split(inputFile, splitFolder);

            // Extract the audio from all the segments and put the audio files in subfolder "extract".
            ExtractAudio extract = new ExtractAudio();
            string extractFolder = outputFolder + "\\" + "step 2 extract";
            extract.ExtractAll(splitFolder, extractFolder);

            // Transcribe the audio files and put the transcriptions in subfolder "transcribe".
            TranscribeAudio transcribe = new TranscribeAudio();
            string transcribeFolder = outputFolder + "\\" + "step 3 transcribe";
            transcribe.TranscribeAll(extractFolder, transcribeFolder, "en");

            // Convert the transcription files to JSON.
            CreateJsonFiles convert = new CreateJsonFiles();
            string jsonFolder = outputFolder + "\\" + "step 4 json";
            convert.CreateJsonFileAll(transcribeFolder, jsonFolder);
        }
    }
}
