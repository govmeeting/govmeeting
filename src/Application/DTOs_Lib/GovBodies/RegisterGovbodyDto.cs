using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Application.DTOs.Govbodies
{
    public class RegisterGovbodyDto
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string Name { get; set; }
    }
}
