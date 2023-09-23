using RinhaInterpreter.Enums;
using RinhaInterpreter.Functions;
using RinhaInterpreter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace RinhaInterpreter
{
    public class Intepreter
    {
        public static Return Execute(Term term, Dictionary<string, KeyValuePair<string, object>> memory)
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
                Var var = ((Var)term);

                var _scope = memory[var.Text];
                if (_scope.Key == "Bool")
                    return Execute((Bool)_scope.Value, memory);
                if (_scope.Key == "Int")
                    return Execute((Int)_scope.Value, memory);
                if (_scope.Key == "Str")
                    return Execute((Str)_scope.Value, memory);

                throw new NotImplementedException();
            }
            if (term.Kind == "Let")
            {
                Let let = (Let)term;

                memory[let.Name.Text] = new KeyValuePair<string, object>(let.Value.Kind,let.Value);

                return Execute(let.Next, memory);
            }
            if ((term.Kind == "Binary"))
            {
                return ExecuteBinary((Binary)term, memory);
            }
            if (term.Kind == "If")
            {
                return ExecuteIf((If)term, memory);
            }
            if (term.Kind == "Print")
            {
                return ExecutePrint((Print)term, memory);
            }
            if (term.Kind == "Call")
            {
                throw new NotImplementedException();
            }
            if (term.Kind == "Function")
            {
                throw new NotImplementedException();
            }
            else
                throw new NotImplementedException();
        }

        public static Return ExecuteBinary(Binary binary, Dictionary<string, KeyValuePair<string, object>> memory)
        {
            return BinaryEvaluator.BinaryEval(binary, memory);
        }

        public static Return ExecuteIf(If @if, Dictionary<string, KeyValuePair<string, object>> memory)
        {
            var condition = Execute(@if.Condition, memory);
            var @bool = (bool)condition.Value;

            return Execute(@bool ? @if.Then : @if.Otherwise, memory);
        }

        public static Return ExecutePrint(Print print, Dictionary<string, KeyValuePair<string, object>> memory)
        {
            var @return = Execute(print.Value, memory);
            Console.WriteLine(@return.Value);
            return new Return();
        }

        public static Return ExecuteCall(Call call, Dictionary<string, KeyValuePair<string, object>> memory)
        {
            var function = Execute(call.Callee, memory);

            var closure = (Closure)function.Value;

            if (call.Arguments.Count != closure.Parameters.Count)
                throw new Exception("Length not right");

            for (int i = 0; i < closure.Parameters.Count; i++)
            {
                var param = closure.Parameters[i];
                var argument = call.Arguments[i];
                var argumentValue = Execute(argument, memory);
            }

            return Execute(closure.Body, memory);
        }

        public static Return ExecuteFunction(Function func)
        {
            return Return.From(ReturnType.Closure, new Closure() { Body = func.Value, Parameters = func.Parameters.Select(x => x.Text).ToList() });
        }
    }
}
