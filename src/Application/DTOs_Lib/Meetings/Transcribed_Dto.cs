using System.Collections.Generic;

namespace GM.Application.DTOs.Meetings
{
    public class Transcribed_Dto
    {
        public List<TranscribedTalk_Dto> Talks;

        public Transcribed_Dto()
        {
            Talks = new List<TranscribedTalk_Dto>();
        }
    }

    public class TranscribedTalk_Dto
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
        public int WordCount { get; set; }

        public List<TranscribedWord_Dto> Words;

        public TranscribedTalk_Dto(string _transcript, double _confidence)
        {
            Transcript = _transcript;
            Confidence = _confidence;
            Words = new List<TranscribedWord_Dto>();
        }
    }

    public class TranscribedWord_Dto
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

        public TranscribedWord_Dto(string _word, double _confidence, long _startTime,
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
