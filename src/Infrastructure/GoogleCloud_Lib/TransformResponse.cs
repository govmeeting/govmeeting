
using Google.Cloud.Speech.V1P1Beta1;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GM.Application.DTOs.Meetings;

namespace GM.Infrastructure.GoogleCloud
{

    public static class TransformResponse
    {

        /*  === TransformResponse.Simplify method ===
           *  We want to extract all the useful data from the response that comes back from the cloud.
           *  But we don't want the superlous fields that make it more complicated to use.
           *  
           *  The raw response structure contains:
           *  A single unnamed object with a "Results" array.
           *  The "Results" array consists of unnamed objects, each containing:
           *      "Alternatives" array, "ChannelTag" integer, "LanguageCode" string
           *  The "Alternatives" arrays appear to always consists of a single unnamed object containing:
           *      "Transcript" string, "Confidence" decimal, "Words" array
           *      WHEN DOES THIS EVER CONSIST OF MORE THEN ONE ALTERNATIVE?
           *  The "Words" array consists of unnamed objects containing:
           *      "StartTime" object, "EndTime" object, "Word" object
           *  The "StartTime" and "EndTime" objects both contain:
           *      "Seconds" int, "Nanos" integer
           *  The "Word" objects contain:
           *      "Word" string, "Confidence" decimal, "SpeakerTag" integer
           *  
           *  The new structure contains:
           *  A single unnamed object with a "Results" array.
           *  The "Results" array consists of unnamed objects, each containing:
           *      "Transcript" string, "Confidence" decimal, "Words" array and "WordCount" integer
           *  The "Words" array consists of unnamed objects, eash containing:
           *      "Word" string, "Confidence" decimal, "StartTime" integer, "EndTime integer, "speakerTag" integer,
           *      and "WordNum" integer.
           *      Both StartTime and EndTime integers are in milliseconds.
           *      "WordCount" and "WordNum" are new fields added to help in fixing speaker tags,
           *      but we leave them in the final structure for possible future use.
           */

        public static Transcribed_Dto Simpify(RepeatedField<SpeechRecognitionResult> recogResults)
        {
            Transcribed_Dto transcript = new Transcribed_Dto();
            int altCount = 0;
            int wordNum = 0;

            foreach (SpeechRecognitionResult recogResult in recogResults)
            {
                if (recogResult.Alternatives.Count > 1)
                {
                    altCount++;
                    Console.WriteLine($"ERROR: more than 1 alternative - result {altCount}");
                };

                SpeechRecognitionAlternative recogAlt = recogResult.Alternatives[0];

                TranscribedTalk_Dto result = new TranscribedTalk_Dto(recogAlt.Transcript, recogAlt.Confidence)
                {
                    // The new "WordCount" field in Result is populated with the total word count.
                    WordCount = recogAlt.Words.Count,
                };
                Console.WriteLine($"Next result: {recogAlt.Words.Count} words");

                foreach (var item in recogAlt.Words)
                {
                    long startTime = item.StartTime.Seconds * 1000 + item.StartTime.Nanos / 1000000;
                    long endTime = item.EndTime.Seconds * 1000 + item.EndTime.Nanos / 1000000;

                    // The new "WordNum" field in RespWord is popluated with the sequencial "wordnum"
                    wordNum++;
                    result.Words.Add(new TranscribedWord_Dto(item.Word, item.Confidence, startTime, endTime, item.SpeakerTag, wordNum));
                }
                transcript.Talks.Add(result);
            }
            return transcript;
        }


        //  === FixSpeakerTags method ===
        // The LongRunningRecognizeResponse does not put SpeakerTag values
        // on the words initially until it has completed the transcription.
        // At that point, it creates one more result that has the entire text
        // in its Transcript field, and a word array that contains 
        // every word in the entire text. The SpeakerTag fields now contains values.
        // FixSpeakerTags moves the SpeakerTag values from the last result in the response
        // to the corresponding words in the initial results and then removes the final result.

        public static Transcribed_Dto FixSpeakerTags(Transcribed_Dto transcribed)
        {

            int resultCount = transcribed.Talks.Count;
            TranscribedTalk_Dto lastResult = transcribed.Talks[resultCount - 1];
            TranscribedTalk_Dto nextToLastResult = transcribed.Talks[resultCount - 2];

            int lastWordnum = lastResult.Words[^1].WordNum;
            int nextToLastWordnum = nextToLastResult.Words[^1].WordNum;

            // Check that the last result is the one we want. This should be where:
            // * The WordNum of its last word is exactly double the WordNum of the next to last result.
            // * Its text is a zero length string
            // * The first word in its word array has a non-zero SpeakerTag
            if ((lastResult.Transcript != "") ||
                (lastWordnum != nextToLastWordnum * 2) ||
                (lastResult.Words[0].SpeakerTag == 0))
            {
                // TODO - throw exception
                Console.WriteLine("ERROR: Final result with speakerTags not present");
                return null;
            }

            // Now we will populate the Word objects in the prior results with
            // the SpeakerTag of the matching word in the final result.
            int i = 0;
            List<TranscribedWord_Dto> words = lastResult.Words;
            // "results" will be all but last
            List<TranscribedTalk_Dto> results = transcribed.Talks.GetRange(0, resultCount - 1);

            foreach (TranscribedTalk_Dto result in results)
            {
                foreach (TranscribedWord_Dto word in result.Words)
                {
                    TranscribedWord_Dto w = words[i++];
                    if (w.Word != word.Word)
                    {
                        // TODO - throw exception
                        Console.WriteLine(@"ERROR: word {i}: '{w.word}' does not match '{word.word}'");
                        return null;
                    }
                    word.SpeakerTag = w.SpeakerTag;
                }
            }

            // And finally, we delete the last result containing the repeated text.
            transcribed.Talks.RemoveAt(resultCount - 1);
            return transcribed;
        }
        


    }
}
