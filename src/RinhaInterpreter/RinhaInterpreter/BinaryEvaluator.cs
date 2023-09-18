using RinhaInterpreter.Enums;
using RinhaInterpreter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter
{
    public class BinaryEvaluator
    {
        public static Return BinaryEval(Binary term)
        {
            var lhs = Intepreter.Execute(term.Lhs);
            var rhs = Intepreter.Execute(term.Rhs);

            return term.Op switch
            {
                BinaryOp.Add => EvaluateAddition(lhs, rhs),
                BinaryOp.Sub => EvaluateSubtraction(lhs, rhs),
                BinaryOp.Mul => EvaluateMultiplication(lhs, rhs),
                BinaryOp.Div => EvaluateDivision(lhs, rhs),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static Return EvaluateAddition(Return lhs, Return rhs)
        {
            if (lhs.Kind != ReturnType.Int || rhs.Kind != ReturnType.Int)
                throw new InvalidOperationException("Invalid operators");

            return new Return(ReturnType.Int, (int)lhs.Value + (int)rhs.Value);
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
    }
}
