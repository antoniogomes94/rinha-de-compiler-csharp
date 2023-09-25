using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Tuple : Term
    {
        public Term First { get; set; }
        public Term Second { get; set; }
    }
}
