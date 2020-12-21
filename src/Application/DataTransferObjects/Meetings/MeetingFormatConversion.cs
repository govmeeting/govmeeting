using GM.ApplicationCore.Entities.MeetingsDto;
using System;
using System.Collections.Generic;
using System.Text;

//namespace Microsoft.eShopWeb.ApplicationCore.Entities.Meeting
namespace GM.ApplicationCore.Entities.Meetings
{
    public class MeetingFormatConversion
    {
        EditMeetingDto editDto;
        ViewMeetingDto view = new ViewMeetingDto();

        public MeetingFormatConversion(EditMeetingDto _editDto)
        {
            editDto = _editDto;
        }

        public ViewMeetingDto Convert()
        {

            ViewMeetingDto view = new ViewMeetingDto();

            ViewMeetingSectionDto section = null;
            ViewMeetingTopicDiscussionDto topicDisc = null;
            ViewMeetingTalkDto talk = null;

            foreach (EditMeetingTalkDto talkEdit in editDto.Talks)
            {
                if (talkEdit.SectionName != "")
                {
                    if (section != null)
                    {
                        view.Sections.Add(section);
                    }
                    section = new ViewMeetingSectionDto();
                    section.Name = talkEdit.SectionName;
                }
                if (talkEdit.TopicName != "")
                {
                    if (topicDisc != null)
                    {
                        section.TopicDiscussions.Add(topicDisc);
                    }
                    topicDisc = new ViewMeetingTopicDiscussionDto();
                    topicDisc.TopicId = GetOrAddToTopics(talkEdit.TopicName);
                }
                if (talkEdit.SpeakerName != "")
                {
                    if (talk != null)
                    {
                        topicDisc.Talks.Add(talk);
                    }
                    talk = new ViewMeetingTalkDto();
                    talk.SpeakerId = GetOrAddToSpeakers(talkEdit.SpeakerName);
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
            ViewMeetingTopicDto result = view.Topics.Find(x => x.Name == topicName);
            if (result == null)
            {
                ViewMeetingTopicDto topic = new ViewMeetingTopicDto() {
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
            ViewMeetingSpeakerDto result = view.Speakers.Find(x => x.Name == speakerName);
            if (result == null)
            {
                ViewMeetingSpeakerDto speaker = new ViewMeetingSpeakerDto()
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
