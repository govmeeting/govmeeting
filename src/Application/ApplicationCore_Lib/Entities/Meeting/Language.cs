using Ardalis.GuardClauses;

namespace GM.ApplicationCore.Entities.Meetings
{
    public class Language : BaseEntity
    {
        public Language(string name)
        {
            Name = name;

            Guard.Against.NullOrEmpty(name, nameof(name));
        }
        public string Name { get; set; }
    }
}
