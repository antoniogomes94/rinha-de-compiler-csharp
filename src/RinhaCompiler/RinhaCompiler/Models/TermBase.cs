using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public abstract class TermBase
    {
        public string Kind { get; set; }
        public Location Location { get; set; }
    }
}
