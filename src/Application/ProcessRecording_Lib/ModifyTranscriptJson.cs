using System;
using System.Collections.Generic;
using System.Text;
using GM.Infrastructure.GoogleCloud;
using GM.Application.DTOs.Meetings;

namespace GM.Application.ProcessRecording
{

    /**********************************************************************
     * Modify the Google speech output to our own "MeetingEditDto" format.
     ***********************************************************************/

    public class ModifyTranscriptJson
    {

        public EditMeeting_Dto Modify(Transcribed_Dto transcript)
        {
            EditMeeting_Dto editmeeting = new EditMeeting_Dto();
            int wordNum = 0;   // running word sequence number

            foreach (TranscribedTalk_Dto result in transcript.Talks)
            {
                EditMeetingTalk_Dto talk = new EditMeetingTalk_Dto(result.Transcript, result.Confidence);
                int speaker = -1;

                foreach (TranscribedWord_Dto respword in result.Words)
                {
                    EditMeetingWord_Dto word = new EditMeetingWord_Dto(
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
                            talk = new EditMeetingTalk_Dto(result.Transcript, result.Confidence);
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

        public EditMeeting_Dto Modify2(Transcribed_Dto transcript)
        {
            EditMeeting_Dto editmeeting = new EditMeeting_Dto();
            int wordNum = 0;   // running word sequence number

            foreach (TranscribedTalk_Dto result in transcript.Talks)
            {
                EditMeetingTalk_Dto talk = new EditMeetingTalk_Dto(result.Transcript, result.Confidence);
               int speaker = -1;
                 
               foreach (TranscribedWord_Dto respword in result.Words)
                {
                    EditMeetingWord_Dto word = new EditMeetingWord_Dto(
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

                    talk.SpeakerName = speaker switch
                    {
                        0 => "UNKOWN",
                        -2 => "DIFFERENT",
                        _ => "Speaker " + speaker.ToString(),
                    };
                    talk.Words.Add(word);

                }
                editmeeting.Talks.Add(talk);
            }
            return editmeeting;
        }
    }
}
