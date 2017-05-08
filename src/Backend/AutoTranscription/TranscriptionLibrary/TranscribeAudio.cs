using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Speech.V1;


namespace TranscriptionLibrary
{
    public class TranscribeAudio
    {
        public string Transcribe(string path, string language)
        {
            if (true) return "xxxx";
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