using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Let : Term
    {
        public Parameter Name { get; set; }
        public Term Value { get; set; }
        public Term Next { get; set; }
    }
}
