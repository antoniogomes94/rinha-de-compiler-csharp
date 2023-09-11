using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class Binary : TermBase
    {
        public Term Lhs { get; set; }
        public BinaryOp Op { get; set; }
        public Term Rhs { get; set; }
    }
}
