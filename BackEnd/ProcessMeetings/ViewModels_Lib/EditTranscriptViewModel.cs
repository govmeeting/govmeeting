using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ViewModels
{
    public class EditTranscriptViewModel
    {
        public List<string> sections { get; set; }
        public List<string> topics { get; set; }
        public List<Talk> talks { get; set; }
		public long lastedit { get; set; }  // time into transcript of last edit

        public EditTranscriptViewModel()
        {
            talks = new List<Talk>();
        }
    }

    public class Talk
    {
        public string speaker { get; set; }
        public string said { get; set; }
        public string section { get; set; }
        public string topic { get; set; }
        public bool showSetTopic { get; set; }
        public double confidence { get; set; }
        public int wordcount { get; set; }
        public List<Word> words { get; set; }
		
		public Talk(string _said, double _confidence) 
		{
			said = _said;
			confidence = _confidence;
            words = new List<Word>();
		}
    }

    public class Word
    {
        public string word { get; set; }
        public double confidence { get; set; }
        public long starttime { get; set; }
        public long endtime { get; set; }
        public int speaker { get; set; }
        public int wordnum { get; set; }
		
		public Word( 
			string _word,
			double _confidence,
			long _starttime,
			long _endtime,
			int _speaker,
			int _wordnum
		)
		{
			word = _word;
			confidence = _confidence;
			starttime = _starttime;
			endtime = _endtime;
			speaker = _speaker;
			wordnum = _wordnum;
		}	
    }
}
