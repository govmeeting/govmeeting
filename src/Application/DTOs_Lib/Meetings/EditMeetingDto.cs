using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Application.DTOs.Meetings
{
    // The MeetingEditDto represents the transcribed meeting in process
    // of being edited (proofread and tagged). While it's being edited,
    // many changes may be made to the structure of the data:
    //  * the position of the start of a section may be moved.
    //  * the start of a new topic will be added and possibly later changed.
    //  * the text associated with a specific speaker can be changed
    //  * the start and end positions of when someone speakes can be changed.
    // A main goal of the editing code is to be as responsive as possible.
    // Therefore, we want a data structure that can be modified quickly.
    // We don't want to have to restructure the data on every change.
    // Therefore, you will note that:
    //   * every MeetingEditWord instance include the speaker value
    //   * every 
    // As it's being edited, the transcript is saved at intervals to the server.
    // A user can in this way temporarily stop editing and continue later.
    // Copies of the transcript are saved by converting this structure to a string
    // and saving the string to a file. Each time a save is done, it's saved to a new
    // file, up to 'MaxWorkFileBackups' total copies, where MaxWorkFileBackups is defined
    // in appsettings.Shared.json.

    public class EditMeetingDto
    {
        public List<string> Sections { get; set; }
        public List<string> Topics { get; set; }
        public List<EditMeetingTalkDto> Talks { get; set; }
		public long LastEdit { get; set; }  // time into transcript of last edit

        public EditMeetingDto()
        {
            Talks = new List<EditMeetingTalkDto>();
        }
    }

    public class EditMeetingTalkDto
    {
        public string Transcript { get; set; }
        public double Confidence { get; set; }
        public int WordCount { get; set; }
        public string SpeakerName { get; set; }
        public string SectionName { get; set; }
        public string TopicName { get; set; }
        public bool ShowSetTopic { get; set; }
        // whether to show "SetTopic" at this location during editing
        public List<EditMeetingWordDto> Words { get; set; }
		
		public EditMeetingTalkDto(string _transcript, double _confidence) 
		{
			Transcript = _transcript;
			Confidence = _confidence;
            Words = new List<EditMeetingWordDto>();
		}
    }

    public class EditMeetingWordDto
    {
        public string Word { get; set; }
        public double Confidence { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int WordNum { get; set; }
        public int SpeakerTag { get; set; }

        public EditMeetingWordDto( string _word, double _confidence, long _starttime,
			long _endtime, int _speaker, int _wordnum
		)
		{
			Word = _word;
			Confidence = _confidence;
			StartTime = _starttime;
			EndTime = _endtime;
			SpeakerTag = _speaker;
			WordNum = _wordnum;
		}	
    }
}
