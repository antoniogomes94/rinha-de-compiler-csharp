using RinhaInterpreter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public  class Return
    {
        public Return(ReturnType kind, object value)
        {
            Kind = kind;
            Value = value;
        }

        public Return()
        {

        }

        public ReturnType Kind { get; set; }
        public object Value { get; set; }


    }
}
