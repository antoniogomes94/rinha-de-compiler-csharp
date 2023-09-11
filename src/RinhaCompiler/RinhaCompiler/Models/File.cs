using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public  class File
    {
        public string Name { get; set; }
        public Term Expression { get; set; }
        public Location Location { get; set; }
    }
}
