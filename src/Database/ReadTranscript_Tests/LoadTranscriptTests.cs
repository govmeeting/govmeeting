using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using Govmeeting.Backend.ReadTranscript;
using Govmeeting.Backend.Model;

namespace Govmeeting.Backend.ReadTranscript.Tests
{
    [TestFixture()]
    public class LoadTranscriptTests
    {
        /*
        StandardKernel kernel;

        [TestFixtureSetUp]
        public void PerFixtureSetup()
        {
            kernel = new StandardKernel();
        }
        [TestFixtureTearDown]
        public void PerFixtureTeardown()
        {
            kernel.Dispose();
        }
        */

        [Test()]
        public void Backend_ReadTranscript_LoadHeadingInfo_Simple()
        {
            // ARRANGE
            List<Field> nextFields = new List<Field>
            {
                new Field() {Name = "Body", Value = "Anyville Town Council"},
                new Field() {Name = "Country", Value = "USA"},
                new Field() {Name = "State", Value = "NJ"},
                new Field() {Name = "County", Value = "Lincoln"},
                new Field() {Name = "Municipality", Value = "Anyville"},
                new Field() {Name = "Date", Value = "Aug 1, 2015"},
                new Field() {Name = "Unknown", Value = "anything"},
            };
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IReadTranscriptFields>().To<ReadTranscriptFields_stub>().WithConstructorArgument("nextFields", nextFields);
            ReadTranscriptFile loadTranscript = kernel.Get<ReadTranscriptFile>();
            
            // ACT
            GovernmentBody govBody = loadTranscript.LoadHeadingInfo();

            // ASSERT
            Assert.That(govBody.Name, Is.EqualTo("Anyville Town Council"));
            Assert.That(govBody.Country, Is.EqualTo("USA"));
            Assert.That(govBody.State, Is.EqualTo("NJ"));
            Assert.That(govBody.County, Is.EqualTo("Lincoln"));
            Assert.That(govBody.Municipality, Is.EqualTo("Anyville"));
        }

        [Test()]
        public void Backend_ReadTranscript_LoadMeetingData_OneTopicOneSpeaker()
        {
            // ARRANGE
            List<Field> nextFields = new List<Field>
            {
                new Field() {Name = "Topic", Value = "Swimming pool"},
                new Field() {Name = "Category", Value = "Recreation"},
                new Field() {Name = "Speaker", Value = "Councilperson Jones"},
                new Field() {Name = "Text", Value = "It's too expensive."},
            };
            List<Category> categories = new List<Category>();
            List<Topic> topics = new List<Topic>();

            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IReadTranscriptFields>().To<ReadTranscriptFields_stub>().WithConstructorArgument("nextFields", nextFields);
            ReadTranscriptFile loadTranscript = kernel.Get<ReadTranscriptFile>();

            // ACT
            Meeting meeting = loadTranscript.LoadMeetingData(categories, topics);

            // ASSERT
            TopicDiscussion td; Category c; Talk t;
            // Check that the Meeting object model was populated correctly
            Assert.That(td = meeting.TopicDiscussions[0], Is.Not.Null);
            Assert.That(td.Topic.Name, Is.EqualTo("Swimming pool"));
            Assert.That(c = td.Topic.Categories[0], Is.Not.Null);
            Assert.That(c.Name, Is.EqualTo("Recreation"));
            Assert.That(t = td.Talks[0], Is.Not.Null);
            Assert.That(t.Text, Is.EqualTo("It's too expensive."));
        }

        [Test()]
        public void Backend_ReadTranscript_LoadMeetingData_MultipleTopicsCategoriesAndSpeakers()
        {
            // ARRANGE
            List<Field> nextFields = new List<Field>
            {
                new Field() {Name = "Topic", Value = "Swimming pool"},
                new Field() {Name = "Category", Value = "Recreation"},
                new Field() {Name = "Speaker", Value = "Mr. Smith"},
                new Field() {Name = "Text", Value = "It's too expensive."},
                new Field() {Name = "Speaker", Value = "Mrs. Jones"},
                new Field() {Name = "Text", Value = "No, it's not."},

                new Field() {Name = "Topic", Value = "More police"},
                new Field() {Name = "Category", Value = "Safety"},
                new Field() {Name = "Speaker", Value = "Mrs. Lane"},
                new Field() {Name = "Text", Value = "They're not needed."},
                new Field() {Name = "Speaker", Value = "Mr. Bull"},
                new Field() {Name = "Text", Value = "Yes they are."},
                new Field() {Name = "Speaker", Value = "Mr. Rames"},
                new Field() {Name = "Text", Value = "I'm not sure."},

                new Field() {Name = "Topic", Value = "Widen Main street"},
                new Field() {Name = "Category", Value = "Transportation"},
                new Field() {Name = "Category", Value = "Local Business"},
                new Field() {Name = "Speaker", Value = "Mrs. Williams"},
                new Field() {Name = "Text", Value = "We need it."},
            };
            List<Category> categories = new List<Category>();
            List<Topic> topics = new List<Topic>();

            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IReadTranscriptFields>().To<ReadTranscriptFields_stub>().WithConstructorArgument("nextFields", nextFields);
            ReadTranscriptFile loadTranscript = kernel.Get<ReadTranscriptFile>();

            // ACT
            Meeting meeting = loadTranscript.LoadMeetingData(categories, topics);

            // ASSERT
            List<TopicDiscussion> tds = meeting.TopicDiscussions;
            // Check that the Meeting object model was populated correctly
            Assert.That(tds.Count, Is.EqualTo(3));
            Assert.That(tds[0].Talks.Count, Is.EqualTo(2));
            Assert.That(tds[1].Talks.Count, Is.EqualTo(3));
            Assert.That(tds[2].Topic.Categories.Count, Is.EqualTo(2));
        }

    }
}
