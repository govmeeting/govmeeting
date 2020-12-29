using System.Collections.Generic;

namespace GM.Application.DTOs.Meetings
{
    public class TranscribedDto
    {
        public List<TranscribedTalkDto> Talks;

        public TranscribedDto()
        {
            Talks = new List<TranscribedTalkDto>();
        }
    }

    public class TranscribedTalkDto
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
        public int WordCount { get; set; }

        public List<TranscribedWordDto> Words;

        public TranscribedTalkDto(string _transcript, double _confidence)
        {
            Transcript = _transcript;
            Confidence = _confidence;
            Words = new List<TranscribedWordDto>();
        }
    }

    public class TranscribedWordDto
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

        public TranscribedWordDto(string _word, double _confidence, long _startTime,
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
