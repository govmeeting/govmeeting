using System.Collections.Generic;

namespace GM.GoogleCloud
{
    public class TranscribedDto
    {
        public List<TranscribedTalk> Talks;

        public TranscribedDto()
        {
            Talks = new List<TranscribedTalk>();
        }
    }

    public class TranscribedTalk
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
        public int WordCount { get; set; }

        public List<TranscribedWord> Words;

        public TranscribedTalk(string _transcript, double _confidence)
        {
            Transcript = _transcript;
            Confidence = _confidence;
            Words = new List<TranscribedWord>();
        }
    }

    public class TranscribedWord
    {
        /* startTime and endTime are time in milliseconds since start of recording.
         * An C# int is equivalent to int32 which has a max value of 2147483647.
         * Using an int, means we can handle meetings up to 596 hours long.
         */
        public string Word { get; set; }
        public double Confidence { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int WordNum { get; set; }
        public int SpeakerTag { get; set; }

        public TranscribedWord(string _word, double _confidence, long _startTime,
            long _endTime, int _speakerTag, int _wordNum)
        {
            Word = _word;
            Confidence = _confidence;
            StartTime = _startTime;
            EndTime = _endTime;
            WordNum = _wordNum;
            SpeakerTag = _speakerTag;
        }
    }
}
