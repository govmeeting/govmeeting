using System.Collections.Generic;

namespace GM.GoogleCloud
{
    public class TranscribeResult
    {
        public List<Result> results;

        public TranscribeResult()
        {
            results = new List<Result>();
        }
    }

    public class Result
    {
        public string text;
        public double confidence;
        public int wordCount;
        public List<RespWord> words;
        public Result(string _text)
        {
            text = _text;
            words = new List<RespWord>();
        }
    }

    public class RespWord
    {
        /* startTime and endTime are time in milliseconds since start of recording.
         * An C# int is equivilent to int32 which has a max value of 2147483647.
         * Using an int, means we can handle meetings up to 596 hours long.
         */
        public string word;
        public double confidence;
        public long startTime;
        public long endTime;
        public int speakerTag;
        public int wordNum;

        public RespWord(string _word, double _confidence, long _startTime, long _endTime, int _speakerTag, int _wordNum)
        {
            word = _word;
            confidence = _confidence;
            startTime = _startTime;
            endTime = _endTime;
            wordNum = _wordNum;
            speakerTag = _speakerTag;
        }
    }
}
