using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Call : Term
    {
        public Term Callee { get; set; }
        public List<Term> Arguments { get; set; }
    }
}
