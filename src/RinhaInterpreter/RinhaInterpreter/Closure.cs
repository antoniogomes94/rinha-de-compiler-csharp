using RinhaInterpreter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter
{
    public class Closure
    {
        public Term Body { get; set; }
        public List<string> Parameters { get; set; }
    }
}
