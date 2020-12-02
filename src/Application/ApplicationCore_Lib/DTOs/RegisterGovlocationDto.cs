using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ViewModels
{
    public enum GovlocType
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
        public GovlocType Type;
    }

    public class RegisterGovlocationDto
    {
        List<GovLocationDto> Locations;
    }
}

