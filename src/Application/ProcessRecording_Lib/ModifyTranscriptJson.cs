using System;
using System.Collections.Generic;
using System.Text;
using GM.ViewModels;
using GM.GoogleCloud;

namespace GM.ProcessRecording
{

    /**********************************************************************
     * Modify the Google speech output to our own "MeetingEditDto" format.
     ***********************************************************************/

    public class ModifyTranscriptJson
    {

        public MeetingEditDto Modify(TranscribedDto transcript)
        {
            MeetingEditDto editmeeting = new MeetingEditDto();
            int wordNum = 0;   // running word sequence number

            foreach (TranscribedTalk result in transcript.Talks)
            {
                MeetingEditTalk talk = new MeetingEditTalk(result.Transcript, result.Confidence);
                int speaker = -1;

                foreach (TranscribedWord respword in result.Words)
                {
                    MeetingEditWord word = new MeetingEditWord(
                        respword.Word,
                        respword.Confidence,
                        respword.StartTime,
                        respword.EndTime,
                        respword.SpeakerTag,
                        ++wordNum
                    );
                    if (speaker != word.SpeakerTag)
                    {
                        if (speaker != -1)
                        {
                            editmeeting.Talks.Add(talk);
                            talk = new MeetingEditTalk(result.Transcript, result.Confidence);
                        }
                        speaker = word.SpeakerTag;
                        talk.SpeakerName = "Speaker " + speaker.ToString();
                    }
                    talk.Words.Add(word);
                }
                editmeeting.Talks.Add(talk);
            }
            return editmeeting;
        }

        public MeetingEditDto Modify2(TranscribedDto transcript)
        {
            MeetingEditDto editmeeting = new MeetingEditDto();
            int wordNum = 0;   // running word sequence number

            foreach (TranscribedTalk result in transcript.Talks)
            {
                MeetingEditTalk talk = new MeetingEditTalk(result.Transcript, result.Confidence);
               int speaker = -1;
                 
               foreach (TranscribedWord respword in result.Words)
                {
                    MeetingEditWord word = new MeetingEditWord(
                        respword.Word,
                        respword.Confidence,
                        respword.StartTime,
                        respword.EndTime,
                        respword.SpeakerTag,
                       ++wordNum
                    );

                    // Check if the speaker is the same for all words
                    // "speaker" will equal "-2" if different speakers.
                    if (speaker != -2)
                    {
                        if (speaker == -1)
                        {
                            speaker = word.SpeakerTag;  // we found first speaker (could also be 0)
                        }
                        else
                        {
                            if (speaker != word.SpeakerTag)
                            {
                                speaker = -2;  // we found two speakers do not match
                            }
                        }
                    }

                    switch (speaker)
                    {
                        case 0:
                            talk.SpeakerName = "UNKOWN";
                            break;
                        case -2:
                            talk.SpeakerName = "DIFFERENT";
                            break;
                        default:
                            talk.SpeakerName = "Speaker " + speaker.ToString();
                            break;
                    }

                    talk.Words.Add(word);

                }
                editmeeting.Talks.Add(talk);
            }
            return editmeeting;
        }
    }
}
