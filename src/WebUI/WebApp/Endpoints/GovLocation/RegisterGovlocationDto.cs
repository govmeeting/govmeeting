using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ViewModels
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

    public class GovLocationDto
    {
        public string Name;
        public GovlocTypes GovLocType;
    }

    public class RegisterGovlocationDto
    {
        List<GovLocationDto> Locations;
    }
}

