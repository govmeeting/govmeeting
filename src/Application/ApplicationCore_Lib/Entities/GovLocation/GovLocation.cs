using System;
using System.Collections.Generic;
using System.Text;
using GM.ApplicationCore.Interfaces;
using GM.ApplicationCore.Entities.Meetings;
using Ardalis.GuardClauses;
using GM.ApplicationCore.Entities.Topics;

namespace GM.ApplicationCore.Entities.Govbodies
{
    public enum GovlocTypes
    {
        City,
        Town,
        Borough,
        Township,
        County,
        StateOrProvince,
        Territory,
        Country
    };


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
            GovLocType = GovLocType;
            Code = code;

            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(code, nameof(code));
        }
        public string Name { get; private set; }
        public GovlocTypes GovLocType { get; set; }
        public string Code { get; private set; }

        /// <summary>
        /// Our parent GovEntity or null if no parent
        /// </summary>
        public int? GovLocationId;

        //public List<Govbody> GovBodies { get; private set; }
        private readonly List<Govbody> _govbodies = new List<Govbody>();
        public IReadOnlyCollection<Govbody> Govbodies => _govbodies.AsReadOnly();

        //public List<Language> Languages { get; private set; }
        private readonly List<Language> _languages = new List<Language>();
        public IReadOnlyCollection<Language> Languages => _languages.AsReadOnly();

        public void AddLanguage(string language)
        {
            _languages.Add(new Language(language));
        }
    }
}
