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
            if (term.Kind == "Var")
            {
                throw new NotImplementedException();
            }
            if (term.Kind == "Let")
            {
                throw new NotImplementedException();
            }
            if ((term.Kind == "Binary"))
            {
                return ExecuteBinary((Binary)term);
            }
            if (term.Kind == "If")
            {
                return ExecuteIf((If)term);
            }
            if (term.Kind == "Print")
            {
                return ExecutePrint((Print)term);
            }
            if (term.Kind == "Call")
            {
                return ExecutePrint((Print)term);
            }
            if (term.Kind == "Function")
            {
                return ExecutePrint((Print)term);
            }
            else
                throw new NotImplementedException();
        }

        public static Return ExecuteBinary(Binary binary)
        {
            return BinaryEvaluator.BinaryEval(binary);
        }

        public static Return ExecuteIf(If @if)
        {
            var condition = Execute(@if.Condition);
            var @bool = (bool)condition.Value;

            return Execute(@bool ? @if.Then : @if.Otherwise);
        }

        public static Return ExecutePrint(Print print)
        {
            var @return = Execute(print.Value);
            Console.WriteLine(@return.Value);
            return new Return();
        }

        public static Return ExecuteCall(Call call)
        {
            var function = Execute(call.Callee);

            var closure = (Closure)function.Value;

            if (call.Arguments.Count != closure.Parameters.Count)
                throw new Exception("Length not right");

            for (int i = 0; i < closure.Parameters.Count; i++)
            {
                var param = closure.Parameters[i];
                var argument = call.Arguments[i];
                var argumentValue = Execute(argument);
            }

            return Execute(closure.Body);
        }

        public static Return ExecuteFunction(Function func)
        {
            return Return.From(ReturnType.Closure, new Closure() { Body = func.Value, Parameters = func.Parameters.Select(x => x.Text).ToList() });
        }
    }
}
