﻿using RinhaInterpreter.Enums;
using RinhaInterpreter.Functions;
using RinhaInterpreter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Tuple = RinhaInterpreter.Models.Tuple;

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
            if (term.Kind == "Tuple")
            {
                return new Return(ReturnType.Tuple, ((Tuple)term));
            }
            if (term.Kind == "Let")
            {
                Let let = (Let)term;

                memory[let.Name.Text] = new KeyValuePair<string, object>(let.Value.Kind, let.Value);

                return Execute(let.Next, memory);
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
                if (_scope.Key == "Tuple")
                    return Execute((Tuple)_scope.Value, memory);
                if (_scope.Key == "Function")
                    return Execute((Function)_scope.Value, memory);
                if (_scope.Key == "Binary")
                    return Execute((Binary)_scope.Value, memory);

                throw new NotImplementedException();
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
            if (term.Kind == "First")
            {
                First first = ((First)term);
                Return retorno = null;

                if (first.Value.Kind == "Var")
                    retorno = Execute((Var)first.Value, memory);
                else if (first.Value.Kind == "Tuple")
                    retorno = Execute((Tuple)first.Value, memory);
                else if (first.Value.Kind == "First")
                    return Execute((First)first.Value, memory);
                else if (first.Value.Kind == "Second")
                    return Execute((Second)first.Value, memory);
                else
                    throw new NotImplementedException();

                Tuple tuple = (Tuple)retorno.Value;

                if (tuple.First.Kind == "Bool")
                    return Execute((Bool)tuple.First, memory);
                if (tuple.First.Kind == "Int")
                    return Execute((Int)tuple.First, memory);
                if (tuple.First.Kind == "Str")
                    return Execute((Str)tuple.First, memory);
                if (tuple.First.Kind == "Tuple")
                    return Execute((Tuple)tuple.First, memory);
                if (tuple.First.Kind == "Function")
                    return Execute((Function)tuple.First, memory);
                if (tuple.First.Kind == "Binary")
                    return Execute((Binary)tuple.First, memory);

                throw new NotImplementedException();
            }
            if (term.Kind == "Second")
            {
                Second second = ((Second)term);
                Return retorno = null;

                if (second.Value.Kind == "Var")
                    retorno = Execute((Var)second.Value, memory);
                else if (second.Value.Kind == "Tuple")
                    retorno = Execute((Tuple)second.Value, memory);
                else if (second.Value.Kind == "First")
                    return Execute((First)second.Value, memory);
                else if (second.Value.Kind == "Second")
                    return Execute((Second)second.Value, memory);
                else
                    throw new NotImplementedException();

                Tuple tuple = (Tuple)retorno.Value;

                if (tuple.Second.Kind == "Bool")
                    return Execute((Bool)tuple.Second, memory);
                if (tuple.Second.Kind == "Int")
                    return Execute((Int)tuple.Second, memory);
                if (tuple.Second.Kind == "Str")
                    return Execute((Str)tuple.Second, memory);
                if (tuple.Second.Kind == "Tuple")
                    return Execute((Tuple)tuple.Second, memory);
                if (tuple.Second.Kind == "Function")
                    return Execute((Function)tuple.Second, memory);
                if (tuple.Second.Kind == "Binary")
                    return Execute((Binary)tuple.Second, memory);

                throw new NotImplementedException();

            }
            if (term.Kind == "Call")
            {
                Call call = (Call)term;
                var functionCallee = Execute(call.Callee, memory);
                Closure closure = (Closure)functionCallee.Value;
                var localMemory = new Dictionary<string, KeyValuePair<string, object>>();

                if (closure.Parameters.Count != call.Arguments.Count)
                    throw new Exception($"Invalid number of parameters for function");

                foreach (var a in memory)
                    localMemory.Add(a.Key, a.Value);

                for (var index = 0; index < closure.Parameters.Count; index++)
                {
                    var parameterReturn = Execute(call.Arguments[index], memory);

                    if (parameterReturn.Kind == ReturnType.Bool)
                        localMemory[closure.Parameters[index]] = new KeyValuePair<string, object>("Bool", new Bool() { Kind = "Int", Value = (bool)parameterReturn.Value });
                    if (parameterReturn.Kind == ReturnType.Int)
                        localMemory[closure.Parameters[index]] = new KeyValuePair<string, object>("Int", new Int() { Kind = "Int", Value = (int)parameterReturn.Value });
                    if (parameterReturn.Kind == ReturnType.Str)
                        localMemory[closure.Parameters[index]] = new KeyValuePair<string, object>("Str", new Str() { Kind = "Int", Value = parameterReturn.Value.ToString() });
                }

                return Execute(closure.Body, localMemory);
            }
            if (term.Kind == "Function")
            {
                Function function = (Function)term;
                return new Return(ReturnType.Closure, new Closure() { Body = function.Value, Memory = memory, Parameters = function.Parameters.Select(x => x.Text).ToList() });
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
    }
}
