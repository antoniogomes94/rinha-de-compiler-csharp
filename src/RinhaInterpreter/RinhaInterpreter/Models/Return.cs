using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public  class Return
    {
        public Return(string kind, object value)
        {
            Kind = kind;
            Value = value;
        }

        public Return()
        {

        }

        public string Kind { get; set; }
        public object Value { get; set; }


    }
}
