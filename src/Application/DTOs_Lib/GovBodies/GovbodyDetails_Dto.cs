using System.Collections.Generic;

namespace GM.Application.DTOs.Govbodies
{
    public class GovbodyDetails_Dto
    {
        public string Name { get; set; }
        public int ParentLocationId { get; set;}
        public List<ElectedOfficial_Dto> ElectedOfficials { get; set; }
        public List<AppointedOfficial_Dto> AppointedOfficials { get; set; }
        public string RecordingsUrl { get; set; }
        public string TranscriptsUrl { get; set; }

    }

    public class Official_Dto
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class ElectedOfficial_Dto : Official_Dto
    {

    }

    public class AppointedOfficial_Dto: Official_Dto
    {

    }
}
