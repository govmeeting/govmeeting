using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Govmeeting.Backend.Model;
//
// We need to use NuGet to install Entity Framework 6.1.1 instead of just adding a reference
// to the one on our machine. This will use the latest version of EF.
using System.Data.Entity;

namespace Govmeeting.Backend.DbAccess
{
    /// <summary>
    /// The Entity Framework context
    /// </summary>
    public class MeetingContext:DbContext
    {
        /// <summary>
        /// Gets or sets the government entities.
        /// </summary>
        /// <value>
        /// The government entities.
        /// </value>
        public DbSet<GovernmentBody> GovernmentBodies { get; set; }

        /// <summary>
        /// Gets or sets the meetings.
        /// </summary>
        /// <value>
        /// The meetings.
        /// </value>
        public DbSet<Meeting> Meetings { get; set; }

        /// <summary>
        /// Gets or sets the talks.
        /// </summary>
        /// <value>
        /// The talks.
        /// </value>
        public DbSet<Talk> Talks { get; set; }

        /// <summary>
        /// Gets or sets the topic discussions.
        /// </summary>
        /// <value>
        /// The topic discussions.
        /// </value>
        public DbSet<TopicDiscussion> TopicDiscussions { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        public DbSet<Topic> Topics { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the speakers.
        /// </summary>
        /// <value>
        /// The speakers.
        /// </value>
        public DbSet<Speaker> Speakers { get; set; }

        /// <summary>
        /// Gets or sets the representatives.
        /// </summary>
        /// <value>
        /// The representatives.
        /// </value>
        public DbSet<Representative> Representatives { get; set; }

        /// <summary>
        /// Gets or sets the citizens.
        /// </summary>
        /// <value>
        /// The citizens.
        /// </value>
        public DbSet<Citizen> Citizens { get; set; }

    }
}
