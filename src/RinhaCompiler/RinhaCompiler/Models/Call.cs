using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class Call : TermBase
    {
        public Term Callee { get; set; }
        public List<Term> Arguments { get; set; }
    }
}
