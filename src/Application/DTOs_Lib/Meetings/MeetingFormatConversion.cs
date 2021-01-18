using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Application.DTOs.Meetings
{
    public class MeetingFormatConversion
    {
        readonly EditMeeting_Dto editDto;
        readonly ViewMeeting_Dto view = new ViewMeeting_Dto();

        public MeetingFormatConversion(EditMeeting_Dto _editDto)
        {
            editDto = _editDto;
        }

        public ViewMeeting_Dto Convert()
        {

            ViewMeeting_Dto view = new ViewMeeting_Dto();

            ViewMeetingSection_Dto section = null;
            ViewMeetingTopicDiscussion_Dto topicDisc = null;
            ViewMeetingTalk_Dto talk = null;

            foreach (EditMeetingTalk_Dto talkEdit in editDto.Talks)
            {
                if (talkEdit.SectionName != "")
                {
                    if (section != null)
                    {
                        view.Sections.Add(section);
                    }
                    section = new ViewMeetingSection_Dto
                    {
                        Name = talkEdit.SectionName
                    };
                }
                if (talkEdit.TopicName != "")
                {
                    if (topicDisc != null)
                    {
                        section.TopicDiscussions.Add(topicDisc);
                    }
                    topicDisc = new ViewMeetingTopicDiscussion_Dto
                    {
                        TopicId = GetOrAddToTopics(talkEdit.TopicName)
                    };
                }
                if (talkEdit.SpeakerName != "")
                {
                    if (talk != null)
                    {
                        topicDisc.Talks.Add(talk);
                    }
                    talk = new ViewMeetingTalk_Dto
                    {
                        SpeakerId = GetOrAddToSpeakers(talkEdit.SpeakerName)
                    };
                }
                talk.Text = talkEdit.Transcript;
            }
            topicDisc.Talks.Add(talk);
            section.TopicDiscussions.Add(topicDisc);
            view.Sections.Add(section);


            return view;
        }

        // If this topic already exists, return ID. Otherwise create it first
        // and add it to the list of topics.
        private long GetOrAddToTopics(string topicName)
        {
            ViewMeetingTopic_Dto result = view.Topics.Find(x => x.Name == topicName);
            if (result == null)
            {
                ViewMeetingTopic_Dto topic = new ViewMeetingTopic_Dto() {
                    TopicId = view.Topics.Count + 1,
                    Name = topicName,
                    IsExisting = false };
                view.Topics.Add(topic);
            }
            return result.TopicId;
        }

        // If this speaker already exists, return ID. Otherwise create it first
        // and add it to the list of speakers.
        private long GetOrAddToSpeakers(string speakerName)
        {
            ViewMeetingSpeaker_Dto result = view.Speakers.Find(x => x.Name == speakerName);
            if (result == null)
            {
                ViewMeetingSpeaker_Dto speaker = new ViewMeetingSpeaker_Dto()
                {
                    SpeakerId = view.Speakers.Count + 1,
                    Name = speakerName,
                };
                view.Speakers.Add(speaker);
            }
            return result.SpeakerId;
        }


    }
}
