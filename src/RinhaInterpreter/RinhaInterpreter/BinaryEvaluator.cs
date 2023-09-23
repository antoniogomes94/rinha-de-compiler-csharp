using RinhaInterpreter.Enums;
using RinhaInterpreter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter
{
    public class BinaryEvaluator
    {
        public static Return BinaryEval(Binary term, Dictionary<string, KeyValuePair<string, object>> memory)
        {
            var lhs = Intepreter.Execute(term.Lhs, memory);
            var rhs = Intepreter.Execute(term.Rhs, memory);

            return term.Op switch
            {
                BinaryOp.Add => EvaluateAddition(lhs, rhs),
                BinaryOp.Sub => EvaluateSubtraction(lhs, rhs),
                BinaryOp.Mul => EvaluateMultiplication(lhs, rhs),
                BinaryOp.Div => EvaluateDivision(lhs, rhs),
                BinaryOp.Rem => EvaluateRemainder(lhs, rhs),
                BinaryOp.Lt => EvaluateLessThan(lhs, rhs),
                BinaryOp.Gt => EvaluateGreaterThan(lhs, rhs),
                BinaryOp.Lte => EvaluateLessThanOrEqual(lhs, rhs),
                BinaryOp.Gte => EvaluateGreaterThanOrEqual(lhs, rhs),
                BinaryOp.And => EvaluateLogicalAnd(lhs, rhs),
                BinaryOp.Or => EvaluateLogicalOr(lhs, rhs),
                BinaryOp.Eq => EvaluateEquality(lhs, rhs),
                BinaryOp.Neq => EvaluateInequality(lhs, rhs),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static Return EvaluateAddition(Return lhs, Return rhs)
        {
            if (lhs.Kind == ReturnType.Int && rhs.Kind == ReturnType.Int)
                return new Return(ReturnType.Int, (int)lhs.Value + (int)rhs.Value);

            return new Return(ReturnType.Str, lhs.Value.ToString() + rhs.Value.ToString());
        }

        private static Return EvaluateSubtraction(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value - (int)rhs.Value);
        }

        private static Return EvaluateMultiplication(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value * (int)rhs.Value);
        }

        private static Return EvaluateDivision(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value / (int)rhs.Value);
        }

        private static Return EvaluateRemainder(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value % (int)rhs.Value);
        }

        private static Return EvaluateEquality(Return lhs, Return rhs) {

            if (lhs.Kind == ReturnType.Int && rhs.Kind == ReturnType.Int)
                return new Return(ReturnType.Bool, (int)lhs.Value == (int)rhs.Value);

            if (lhs.Kind == ReturnType.Str && rhs.Kind == ReturnType.Str)
                return new Return(ReturnType.Bool, lhs.Value.ToString() == rhs.Value.ToString());

            if (lhs.Kind == ReturnType.Bool && rhs.Kind == ReturnType.Bool)
                return new Return(ReturnType.Bool, (bool)lhs.Value == (bool)rhs.Value);

            return new Return(ReturnType.Bool, (int)lhs.Value == (int)rhs.Value);
        }

        private static Return EvaluateInequality(Return lhs, Return rhs) {
            if (lhs.Kind == ReturnType.Int && rhs.Kind == ReturnType.Int)
                return new Return(ReturnType.Bool, (int)lhs.Value != (int)rhs.Value);

            if (lhs.Kind == ReturnType.Str && rhs.Kind == ReturnType.Str)
                return new Return(ReturnType.Bool, lhs.Value.ToString() != rhs.Value.ToString());

            if (lhs.Kind == ReturnType.Bool && rhs.Kind == ReturnType.Bool)
                return new Return(ReturnType.Bool, (bool)lhs.Value != (bool)rhs.Value);

            return new Return(ReturnType.Bool, (int)lhs.Value == (int)rhs.Value);
        }

        private static Return EvaluateLessThan(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value < (int)rhs.Value);
        }

        private static Return EvaluateGreaterThan(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value > (int)rhs.Value);
        }

        private static Return EvaluateLessThanOrEqual(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value <= (int)rhs.Value);
        }

        private static Return EvaluateGreaterThanOrEqual(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value >= (int)rhs.Value);
        }

        private static Return EvaluateLogicalAnd(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Bool || rhs.Kind != ReturnType.Bool)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Bool, (bool)lhs.Value && (bool)rhs.Value);
        }

        private static Return EvaluateLogicalOr(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Bool || rhs.Kind != ReturnType.Bool)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Bool, (bool)lhs.Value || (bool)rhs.Value);
        }
    }
}
