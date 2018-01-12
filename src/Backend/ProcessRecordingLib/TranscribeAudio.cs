using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Google.Cloud.Speech.V1;

// This is in the process of being written.  

namespace GM.ProcessRecordingLib
{

    /*
     * This class is not completed. We will just use a dummy value for transcription text when it is called. See the end of the file.
     */

    public class TranscribeAudio
    {

        public void TranscribeAll(string inputFolder, string outputFolder, string language)
        {
            Directory.CreateDirectory(outputFolder);
            foreach (string f in Directory.GetFiles(inputFolder, "*.flac"))
            {
                string name = Path.GetFileNameWithoutExtension(f);
                Console.WriteLine(f);

                TranscribeToFile(inputFolder + "\\" + name + ".flac", outputFolder + "\\" + name + ".txt", language);
            }
        }

        public void TranscribeToFile(string inputFile, string outputFile, string language)
        {
            string text = Transcribe(inputFile, "en");
            File.WriteAllText(outputFile, text);
        }

        /// <summary>
        /// Transcribe an audio file. The file should not contain more than the maximum
        /// that can be transcibed at one time. Currently this is 3 minutes.
        /// </summary>
        /// <param name="path">Path to the audio file.</param>
        /// <param name="language">Language of the audio. This is the ISO 639 code</param>
        /// <returns>transcription text.</returns>
        public string Transcribe(string path, string language)
        {
            //var speech = SpeechClient.Create();
            //var response = speech.Recognize(new RecognitionConfig()
            //{
            //    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            //    SampleRateHertz = 16000,
            //    LanguageCode = language,
            //}, RecognitionAudio.FromFile(path));
            //foreach (var result in response.Results)
            //{
            //    foreach (var alternative in result.Alternatives)
            //    {
            //        Console.WriteLine(alternative.Transcript);
            //    }
            //}

/*
Youtube used to have an option to generate a transcription of any uploaded video.
It produced the following output, to which is added heading information.  We will
return this as dummy return value, until this class is completed. The final format 
of the data returned from the Google Speech API may be different.
*/
string dummyReturn =  @"
Boothbay Harbor Selectmen - Oct 11, 2016
https://youtu.be/QHRRMNW66Js

00:20 long
0:00
the tuesday october $YEAR 11 selectmen's
0:02
meeting i will apologize apologize for
0:06
my voice i can hardly speak i woke up
0:08
Saturday with a terrible cold so if you
0:10
can't hear me just speak up and i'll try
0:13
to speak louder and you may want to stay
0:14
in the back yeah you guys today in the
0:17
background is yeah I'm like have our
";
            return dummyReturn;
        }
    }
}


