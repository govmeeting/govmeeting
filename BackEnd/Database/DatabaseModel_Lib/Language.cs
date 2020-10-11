using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    public class Language
    {
        public Language(string name)
        {
            Name = name;
        }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
