using RinhaCompiler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaCompiler.Models
{
    public class Function : TermBase
    {
        public List<Parameter> Parameters { get; set; }
        public Term Value { get; set; }
    }
}
