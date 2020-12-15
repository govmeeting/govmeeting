using System;
using System.Collections.Generic;
using System.Text;
using GM.ViewModels;

//namespace Microsoft.eShopWeb.ApplicationCore.Entities.Meeting
namespace GM.ApplicationCore.Entities.Meetings
{
    public class MeetingFormatConversion
    {
        MeetingEditDto editDto;
        MeetingViewDto view = new MeetingViewDto();

        public MeetingFormatConversion(MeetingEditDto _editDto)
        {
            editDto = _editDto;
        }

        public MeetingViewDto Convert()
        {

            MeetingViewDto view = new MeetingViewDto();

            SectionView section = null;
            TopicDiscussionView topicDisc = null;
            TalkView talk = null;

            foreach (MeetingEditTalk talkEdit in editDto.Talks)
            {
                if (talkEdit.SectionName != "")
                {
                    if (section != null)
                    {
                        view.Sections.Add(section);
                    }
                    section = new SectionView();
                    section.Name = talkEdit.SectionName;
                }
                if (talkEdit.TopicName != "")
                {
                    if (topicDisc != null)
                    {
                        section.TopicDiscussions.Add(topicDisc);
                    }
                    topicDisc = new TopicDiscussionView();
                    topicDisc.TopicId = GetOrAddToTopics(talkEdit.TopicName);
                }
                if (talkEdit.SpeakerName != "")
                {
                    if (talk != null)
                    {
                        topicDisc.Talks.Add(talk);
                    }
                    talk = new TalkView();
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
            TopicView result = view.Topics.Find(x => x.Name == topicName);
            if (result == null)
            {
                TopicView topic = new TopicView() {
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
            SpeakerView result = view.Speakers.Find(x => x.Name == speakerName);
            if (result == null)
            {
                SpeakerView speaker = new SpeakerView()
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
