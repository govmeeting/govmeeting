using System;
using Ardalis.GuardClauses;

namespace GM.Application.AppCore.Entities.Speakers
{
    /// <summary>
    /// A Government official - works for and acts on the government's behalf,
    /// but is not elected by the citizens.
    /// </summary>
    public class Official : BaseEntity
    {
        private Official() { }  // for EF

        public Official(string name, long govbodyId, bool? isElected = null)
        {
            Name = name;
            GovbodyId = govbodyId;

            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NegativeOrZero(govbodyId, nameof(govbodyId));
        }
        public string Name { get; set; }
        public long GovbodyId { get; set; }
        public bool IsElected { get; set; }
    }
}
