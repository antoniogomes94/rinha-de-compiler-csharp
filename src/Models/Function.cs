using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Function : Term
    {
        public List<Parameter> Parameters { get; set; }
        public Term Value { get; set; }
    }
}
