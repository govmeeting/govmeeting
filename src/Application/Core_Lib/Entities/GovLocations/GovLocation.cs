using Ardalis.GuardClauses;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Interfaces;
using System.Collections.Generic;

namespace GM.Application.AppCore.Entities.GovLocations
{

    /// <summary>
    /// GovLocation is the place where a Govbody is located,
    /// such as the state, county, city, country
    /// </summary>
    public class GovLocation : BaseEntity, IAggregateRoot
    {
        private GovLocation() { }  // for EF

        public GovLocation(string name, GovlocTypes type, string code)
        {
            Name = name;
            Type = type;
            Code = code;

            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(code, nameof(code));
        }
        public string Name { get; private set; }
        public GovlocTypes Type { get; set; }
        public string Code { get; private set; }

        /// <summary>
        /// Our parent GovLocation or null if no parent
        /// </summary>
        public GovLocation ParentLocation { get; set; }

        private readonly List<Govbody> _govbodies = new List<Govbody>();
        public IReadOnlyCollection<Govbody> Govbodies => _govbodies.AsReadOnly();

        private readonly List<Language> _languages = new List<Language>();
        public IReadOnlyCollection<Language> Languages => _languages.AsReadOnly();

        public void AddLanguage(string language)
        {
            _languages.Add(new Language(language));
        }
    }
}
