using RinhaInterpreter.Enums;
using RinhaInterpreter.Functions;
using RinhaInterpreter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter
{
    public class Intepreter
    {
        public static Return Execute(Term term)
        {
           
            if (term.Kind == "Bool")
            {
                return new Return(ReturnType.Bool, ((Bool)term).Value);
            }
            if (term.Kind == "Int")
            {
                return new Return(ReturnType.Int, ((Int)term).Value);
            }
            if (term.Kind == "Str")
            {
                return new Return(ReturnType.Str, ((Str)term).Value);
            }
            if ((term.Kind == "Binary"))
            {
                return ExecuteBinary((Binary)term);
            }
            if (term.Kind == "Print")
            {
                return ExecutePrint((Print)term);
            }
            else
                throw new NotImplementedException();
        }

        public static Return ExecutePrint(Print print)
        {
            var @return = Execute(print.Value);
            Console.WriteLine(@return.Value);
            return new Return();
        }

        public static Return ExecuteBinary(Binary binary)
        {
            return BinaryEvaluator.BinaryEval(binary);
        }
    }
}
