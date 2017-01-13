using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Govmeeting.Backend.Model;


/*
 * The ReadTranscript class reads a transcript file into an in-memory data model.
 * It does NOT access the database. In other words, it only references the Model project and not DbOperations.
 *
 * LoadHeadingInfo() reads the heading of the transcript file and returns a GovernmentBody object to the caller.
 *
 * Once the caller knows which Government body it is handling, it is able to get a list of topic names for this
 * government body which it then passes in the LoadMeetingData() call.
 *
 * LoadMeetingData() loads the rest of the transcript data. When it encounters a topic or a category, it first checks
 * the existing lists of topics and categories. If it finds that it has a new one, it adds it to the list(s).
 */

/* The following is an example of the beginning of a transcript file.
 * Each field starts with the field name and a ":".
 * The value of the field follows the colon.
 * The exception is the "Text" field (what was said). The text are all lines
 * following the Speaker field up to the next field.
 * 
 * ==== EXAMPLE ====
 * 
 * Body: Boothbay Harbor Selectmen
 * Country: United States
 * State: Maine
 * County: Lincoln
 * Municipality: Boothbay Harbor
 * 
 * Meeting: Boothbay Harbor Selectmen Regular Monthly Meeting
 * Date: Sept. 8, 2014
 * Time: 
 * 
 * Topic: Introductions
 * Category: Meeting Business
 * 
 * Speaker: Denise Griffin
 * Meeting to order. Today is Monday, Sept. 8th.
 * 
 * Speaker: John Jones
 * Welcome to the selectmen’s meeting.
 * 
 * Topic: Prior Minutes
 * Category: Meeting Business
 * 
 * Speaker: Jane Doe
 * I move that we approve the minutes....
 */

namespace Govmeeting.Backend.ReadTranscript
{
    /// <summary>
    /// Class for reading a transcript file into an in-memory Meeting object
    /// </summary>
    public class ReadTranscriptFile
    {
        /// <summary>
        /// If the data is corrupt, we set hadDataError, but continue processing so that the caller
        /// can see all the errors in the file. We return hadDataError to the caller of ReadTranscriptFile
        /// so that it can abort writing this data to database.
        /// </summary>
        Boolean hadDataError = false;

        /// <summary>
        /// The transcript
        /// </summary>
        IReadTranscriptFields transcript;

        /// <summary>
        /// We save speaker names in a list. At the end, we try to resolve them with existing ones.
        /// </summary>
        List<string> speakers = new List<string>();

        /// <summary>
        /// The existing categories
        /// </summary>
        List<Category> existingCategories;

        /// <summary>
        /// The existing topics
        /// </summary>
        List<Topic> existingTopics;

        /// <summary>
        /// The meeting
        /// </summary>
        Meeting meeting = new Meeting();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadTranscriptFile"/> class.
        /// </summary>
        /// <param name="readTranscriptFields">An IReadTranscriptFields object - injected by IoC container.</param>
        public ReadTranscriptFile(IReadTranscriptFields readTranscriptFields)
        {
            transcript = readTranscriptFields;
        }


        /// <summary>
        /// Load the information about the government body that this transcript if for.
        /// </summary>
        /// <returns>
        /// The Government body info in the GovBody object that was passed.
        /// Value of method is false if there was a fatal error in the input.
        /// </returns>
        public GovernmentBody LoadHeadingInfo()
        {
            Field field;
            string meetingTime = "";
            string meetingDate = "";
            GovernmentBody govBody = new GovernmentBody();

            Boolean breakFromLoop = false;
            while (!breakFromLoop && ((field = transcript.ReadNextField()) != null))
            {
                string value = field.Value;
                switch (field.Name)
                {
                    case "Body":
                        govBody.Name = value; break;
                    case "Country":
                        govBody.Country = value; break;
                    case "State":
                        govBody.State = value; break;
                    case "County":
                        govBody.County = value; break;
                    case "Municipality":
                        govBody.Municipality = value; break;
                    case "Date":
                        meetingDate = value; break;
                    case "Time":
                        meetingTime = value; break;
                    case "Meeting":
                        meeting.Name = value; break;
                    default:
                        transcript.PushField(field); // we read an entry that is not in the head section.

                        // if we have the time, add that to the date before setting meeting date.
                        if (!string.IsNullOrEmpty(meetingTime)) meetingDate = meetingDate + " " + meetingTime;
                        meeting.Date = DateTime.Parse(meetingDate);

                        // Todo: We need to accept other date formats that may be in the file instead of just allowing those that DateTime.Parse allows.
                        // We should then change commonly used date formats to one that Parse can use.
                        // We need to document, for the user, the formats of date and time can be added to a transcript file.
                        // Standard Date and Time Format Strings:
                        // http://msdn.microsoft.com/en-us/library/az4se3k1%28v=vs.110%29.aspx
                        // http://www.dotnetperls.com/datetime-parse
                        // https://msdn.microsoft.com/en-us/library/system.globalization.datetimeformatinfo.getshortestdayname(v=vs.110).aspx
                        // In the en-US culture, the first 2 letters of the day and the first 3 letters of the month are acceptable abbreviations.

                        if (string.IsNullOrEmpty(meeting.Name))
                        {
                            // If no meeting name was specified, use the government body name.
                            meeting.Name = govBody.Name;
                        }

                        breakFromLoop = true;
                        break;
                }
            }
            if (CheckHeadingData(govBody))
            {
                return govBody;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Checks the heading data.
        /// </summary>
        /// <param name="govBody">The gov body.</param>
        /// <returns>true if no error. false if error</returns>
        private Boolean CheckHeadingData(GovernmentBody govBody)
        {
            // Check if we have what we need
            if (string.IsNullOrEmpty(govBody.Name)) DataError("Missing name of government body");
            if (string.IsNullOrEmpty(govBody.Country)) DataError("Missing name of country");
            if (meeting.Date == null) DataError("Missing date of meeting");

            return !hadDataError;
        }

        /// <summary>
        /// Load the meeting data from the transcript file into the in-memory Meeting object.
        /// </summary>
        /// <param name="categories">The existing categories. This gets updated if new categories are added.</param>
        /// <param name="topics">The existing topics for this government body. This gets updated if new topics are added.</param>
        /// <returns>
        /// The Meeting object that filled in or null if data error in transcript.
        /// New categories may be added to the category list.
        /// </returns>
        public Meeting LoadMeetingData(List<Category> categories, List<Topic> topics)
        {
            meeting.TopicDiscussions = new List<TopicDiscussion>();

            existingCategories = categories;
            existingTopics = topics;

            // After the heading, we should see topics.
            if (LoadTopicDiscussions(meeting) == 0)
            {
                DataError("Meeting contains no topics");
            }
            return hadDataError ? null : meeting;
        }

        /// <summary>
        /// Loads the topic discussions.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <returns>Number of topics</returns>
        private int LoadTopicDiscussions(Meeting meeting)
        {
            TopicDiscussion topicDiscussion = null;
            Topic topic;
            Field field;
            int topicDiscussionSequence = 0; // sequence # within context of meeting.

            while ((field = transcript.ReadNextField()) != null)
            {
                string value = field.Value;
                switch (field.Name)
                {
                    case "Category":
                    {
                        if (topicDiscussion == null)
                        {
                            DataError("Category with no topic.");
                        }
                        else
                        {
                            Category category = GetExistingOrNewCategory(value);
                            topicDiscussion.Topic.Categories.Add(category);
                        }
                        break;
                    }
                    case "Topic":
                    {
                        // This topic may have already been discussed at this meeting or a past meeting.
                        topic = GetExistingOrNewTopic(value);

                        topicDiscussion = new TopicDiscussion();
                        topicDiscussion.Topic = topic;
                        topicDiscussion.Talks = new List<Talk>();
                        topicDiscussionSequence++;
                        topicDiscussion.Sequence = topicDiscussionSequence;
                        meeting.TopicDiscussions.Add(topicDiscussion);
                        break;
                    }
                    default:
                    {
                        transcript.PushField(field); // we read an entry that's not topic info.

                        // After a topic, we should see talks.
                        // This will process all the talks for this topic.
                        // It returns true if more in file, otherwise false if at file end.
                        if (LoadTalks(topicDiscussion) < 1)
                        {
                            DataError("Topic discussion with no discussion.");
                        }
                    }
                    break;
                }
            }
            return topicDiscussionSequence;
        }

        /// <summary>
        /// Loads the talks.
        /// </summary>
        /// <param name="topicDiscussion">The discussion on a specific topic.</param>
        /// <returns>Number of talks on this topic</returns>
        private int LoadTalks(TopicDiscussion topicDiscussion)
        {
            Talk talk = null;
            Field field;
            int count = 0;
            int talkSequence = 0; // sequence # within context of topic.
            string speakerName = null;

            while ((field = transcript.ReadNextFieldOrText()) != null)
            {

                switch (field.Name)
                {
                    case "Speaker":
                        {
                            speakerName = field.Value;
                            talk = new Talk();
                            int speakerId = speakers.IndexOf(speakerName) + 1;
                            if (speakerId < 1)
                            {
                                speakers.Add(speakerName);
                                speakerId = speakers.Count;
                            }
                            talk.SpeakerId = speakerId;
                            break;
                        }
                    case "Text":
                        {
                            string spokenText = field.Value;
                            if (speakerName == null)
                            {
                                DataError("Missing speaker for text");
                            }
                            else
                            {
                                talk.Text = spokenText;
                                talk.Sequence = ++talkSequence;
                                Speaker speaker = new Speaker();
                                speaker.Name = speakerName;
                                talk.Speaker = speaker;
                                topicDiscussion.Talks.Add(talk);
                                count++;
                            }
                            talk = null;
                            break;
                        }
                    default:
                        {
                            transcript.PushField(field); // We read an entry that's not a talk.
                            return count;
                        }
                }
            };
            return count;  // end of transcript file
        }

        /// <summary>
        /// Gets the existing specified topic. Otherwise creates a new topic with that name.
        /// </summary>
        /// <param name="name">topic name.</param>
        /// <returns>existing or new topic</returns>
        private Topic GetExistingOrNewTopic(string name)
        {
            Topic topic = null;

            if (existingTopics != null)
            {
                var query = from t in existingTopics
                            where t.Name == name
                            select t;
                topic = query.SingleOrDefault();
            }

            if (topic == null)
            {
                topic = new Topic();
                topic.Name = name;
                topic.Categories = new List<Category>();
                existingTopics.Add(topic);
            }
            return topic;
        }

        /// <summary>
        /// Gets the existing specified category. Otherwise creates a new category with that name.
        /// </summary>
        /// <param name="name">category name.</param>
        /// <returns>existing or new category</returns>
        private Category GetExistingOrNewCategory(string name)
        {
            var query = from c in existingCategories
                        where c.Name == name
                        select c;
            var category = query.SingleOrDefault();
            if (category == null)
            {
                category = new Category();
                category.Name = name;
            }
            return category;
        }

        /// <summary>
        /// Writes a data error to the trace and sets the class property hadDataError to true.
        /// </summary>
        /// <param name="message">The message.</param>
        void DataError(string message)
        {
            hadDataError = true;
            Trace.Write("Data Error: " + message + " Linenum = " + transcript.Linenum() + Environment.NewLine);
            Trace.Flush();
        }
    }
}
