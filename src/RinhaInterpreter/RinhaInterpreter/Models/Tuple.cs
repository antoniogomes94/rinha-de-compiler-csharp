using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Tuple : Term
    {
        public Tuple First { get; set; }
        public Tuple Second { get; set; }
    }
}
