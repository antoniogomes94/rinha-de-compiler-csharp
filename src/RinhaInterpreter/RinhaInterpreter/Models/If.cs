using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class If : Term
    {
        public Term Condition { get; set; }
        public Term Then { get; set; }
        public Term Otherwise { get; set; }
    }

}
