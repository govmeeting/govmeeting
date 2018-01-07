using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Speech.V1;

// This is in the process of being written.  

namespace GM.ProcessRecordingLib
{
    public class TranscribeAudio
    {
        /// <summary>
        /// Transcribe an audio file. The file should not contain more than the maximum
        /// that can be transcibed at one time. Currently this is 3 minutes.
        /// </summary>
        /// <param name="path">Path to the audio file.</param>
        /// <param name="language">Language of the audio. This is the ISO 639 code</param>
        /// <returns>transcription text.</returns>
        public string Transcribe(string path, string language)
        {
            //if (true) return "xxxx";
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = language,
            }, RecognitionAudio.FromFile(path));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return "xxxx";
        }
    }
}


/*
 * See Google Speech API samples in: D:\SOURCECODE\dotnet-docs-samples-master\speech
 */