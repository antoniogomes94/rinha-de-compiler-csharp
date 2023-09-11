using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class If : TermBase
    {
        public Term Condition { get; set; }
        public Term Then { get; set; }
        public Term Otherwise { get; set; }
    }
}
