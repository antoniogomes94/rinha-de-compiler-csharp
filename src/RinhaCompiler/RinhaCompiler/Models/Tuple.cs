using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class Tuple : TermBase
    {
        public Tuple First { get; set; }
        public Tuple Second { get; set; }
    }
}
