﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    public class Language
    {
        public int Id { get; set; }
        // Ths ISO id for the language
        public string ISOId { get; set; }
        public string Name { get; set; }
    }
}
