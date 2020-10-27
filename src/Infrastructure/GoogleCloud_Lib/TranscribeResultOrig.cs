using System.Collections.Generic;

namespace GM.GoogleCloud
{
    public class TranscribeResultOrig
    {
        public List<RspAlternative> alternatives;

        public TranscribeResultOrig()
        {
            alternatives = new List<RspAlternative>();
        }
    }

    public class RspAlternative
    {
        public string text;
        public int wordCount;
        public List<RspWord> words;

        public RspAlternative(string _text)
        {
            text = _text;
            words = new List<RspWord>();
        }
    }

    public class RspWord
    {
        /* startTime and endTime are time in milliseconds since start of recording.
         * An C# int is equivilent to int32 which has a max value of 2147483647.
         * Using an int, means we can handle meetings up to 596 hours long.
         */
        public string text;
        public int startTime;
        public int endTime;
        public int position;

        public RspWord(string _text, int _startTime, int _endTime, int _position)
        {
            text = _text;
            startTime = _startTime;
            endTime = _endTime;
            position = _position;
        }
    }
}
