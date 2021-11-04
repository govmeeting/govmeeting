namespace MakeVttSubtitles
{
    // I need to make this new EditTranscriptModel class because the test data
    // that was in clientapp/src/assets/stubdata did not match did not match
    // the current definitions in EditMeeting_Dto

    public class EditMeetingModel
    {
        public string sections;
        public string topics;
        public TalkModel[] talks;
    }

    public class TalkModel
    {
        public string speaker;
        public string said;
        public string? section;
        public string? topic;
        bool showSetTopoc;
        public double confidence;
        public int wordcount;
        public WordModel[] words;
    }

    public class WordModel
    {
        public string word;
        public double confidence;
        public int starttime;
        public int endtime;
        public int speaker;
        public int wordnum;
    }



}
