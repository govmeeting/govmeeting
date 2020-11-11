using Google.Cloud.Speech.V1P1Beta1;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GM.GoogleCloud
{

    /*  === Simplify methos ===
     *  We want to extract all the useful data from the response that comes back from the cloud.
     *  But we don't want the superlous fields that make it more complicated to use.
     *  The raw response has a "Results" object containing an array of results.
     *  Each result has an array of "Alternatives", even though in the LongRunning response 
     *  there is only ever one alternative for each result. Each "Alternative" contains an array
     *  of "Transcript" objects. 
     *  We simplify this by having each "Result" object contain just the arary of "Transcript" objects.
     *  We also:
     *    * Rename "Results" to "results"
     *    * Rename "Transcript: to "text"
     *    * Add a wordcount to each "text"
     *    * Add a sequential wordnum to each word
     *    * Convert starttime and endtime to simple millisec counts instead of {sec, nanos} objects
     *  
     *  === FixSpeakerTags method ===
     *  The raw response from the cloud has two sets of results for the same audio.
     *  The first set is missing the speakerTag values. The second "set" has one result field with each 
     *  word having the speaker tag.
     *  We fix this by:
     *      * Populate speaker tag in the first set of words.
     *      * Remove the final result.
     */

    public static class TransformResponse
    {
        public static TranscribeResult Simpify(RepeatedField<SpeechRecognitionResult> srrs)
        {
            TranscribeResult transcript = new TranscribeResult();
            int resultCount = 0;
            int totalCount = 0;

            foreach (SpeechRecognitionResult srr in srrs)
            {
                if (srr.Alternatives.Count > 1)
                {
                    resultCount++;
                    Console.WriteLine($"ERROR: more than 1 alternative - result {resultCount}");
                };

                SpeechRecognitionAlternative sra = srr.Alternatives[0];

                Result result = new Result(sra.Transcript)
                {
                    wordCount = sra.Words.Count,
                    confidence = sra.Confidence
                };
                Console.WriteLine($"Next result: {sra.Words.Count} words");

                foreach (var item in sra.Words)
                {
                    ;
                    totalCount++;
                    long startTime = item.StartTime.Seconds * 1000 + item.StartTime.Nanos / 1000000;
                    long endTime = item.EndTime.Seconds * 1000 + item.EndTime.Nanos / 1000000;

                    result.words.Add(new RespWord(item.Word, item.Confidence, startTime, endTime, item.SpeakerTag, totalCount));
                }
                transcript.results.Add(result);
            }
            return transcript;
        }

        // The LongRunningRecognizeResponse does not put SpeakerTag values
        // on the words initially until it has completed the transcription.
        // Then it repeats all of the words in the last result and this result
        // contains SpeakerTag values for all words.
        // FixSpeakerTags moves the SpeakerTag values from the last result in the response
        // to the corresponding words in the initial results.
        public static TranscribeResult FixSpeakerTags(TranscribeResult rsp)
        {
            // Find where the results repeat. This should be where
            // * the text is a zero length string
            // * the first word has a speaker number non-zero
            // * its words count equals the last word's wordnum

            Result lastResult = rsp.results[rsp.results.Count - 1];
            Result nextToLastResult = rsp.results[rsp.results.Count - 2];
            int lastWordnum = lastResult.words[lastResult.words.Count - 1].wordNum;
            int nextToLastWordnum = nextToLastResult.words[nextToLastResult.words.Count - 1].wordNum;

            if ((lastResult.text != "") ||
                (lastWordnum != nextToLastWordnum * 2) ||
                (lastResult.words[0].speakerTag == 0))
            {
                Console.WriteLine("ERROR: Final result with speakerTags not present");
                return null;
            }

            int i = 0;
            List<RespWord> words = lastResult.words;
            // "results" will be all but last
            List<Result> results = rsp.results.GetRange(0, rsp.results.Count - 1);

            foreach (Result result in results)
            {
                foreach (RespWord word in result.words)
                {
                    RespWord w = words[i++];
                    if (w.word != word.word)
                    {
                        Console.WriteLine(@"ERROR: word {i}: '{w.word}' does not match '{word.word}'");
                        return null;
                    }
                    word.speakerTag = w.speakerTag;
                }
            }

            rsp.results.RemoveAt(rsp.results.Count - 1);

            return rsp;
        }
        


    }
}
