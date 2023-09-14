using RinhaCompiler.Functions;
using RinhaCompiler.Models;
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
            if (term.Kind == "Print")
            {
                return ExecutePrint((Print)term);
            }
            if (term.Kind == "Bool")
            {
                return new Return("Bool", ((Bool)term).Value);
            }
            if (term.Kind == "Int")
            {
                return new Return("Int", ((Int)term).Value);
            }
            if (term.Kind == "Str")
            {
                return new Return("Srt", ((Str)term).Value);
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
    }
}
