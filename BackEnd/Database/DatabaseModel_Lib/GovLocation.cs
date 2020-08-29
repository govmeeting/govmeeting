using GM.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseModel
{



    public enum GovEntityTypes
    {
        City,
        Town,
        Boro,
        Township,
        County,
        StateOrProvince,
        Territory,
        Country
    };



    /// <summary>
    /// Government Entity an actual place such as state, county, city, country
    /// </summary>
    public class GovLocation
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public GovEntityTypes GovEntityType { get; set; }

        public List<Language> Languages { get; set; }

        /// <summary>
        /// The list of government bodies associated with this entity
        /// </summary>
        public List<GovBody> GovBodies { get; set; }

        /// <summary>
        /// Our parent GovEntity
        /// </summary>
        public long GovLocationId;

    }
}
