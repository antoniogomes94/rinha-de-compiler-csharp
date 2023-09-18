using RinhaInterpreter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RinhaInterpreter.Models
{
    public class Binary : Term
    {
        public Binary(string kind, Term lhs, string binaryOp, Term rhs, Location location)
        {
            Kind = kind;
            Lhs = lhs;
            Rhs = rhs;
            Location = location;

            switch (binaryOp)
            {
                case "Add":
                    Op = BinaryOp.Add;
                    break;
                case "Sub":
                    Op = BinaryOp.Sub;
                    break;
                case "Mul":
                    Op = BinaryOp.Mul;
                    break;
                case "Div":
                    Op = BinaryOp.Div;
                    break;
                case "Rem":
                    Op = BinaryOp.Rem;
                    break;
                case "Eq":
                    Op = BinaryOp.Eq;
                    break;
                case "Neq":
                    Op = BinaryOp.Neq;
                    break;
                case "Lt":
                    Op = BinaryOp.Lt;
                    break;
                case "Gt":
                    Op = BinaryOp.Gt;
                    break;
                case "Lte":
                    Op = BinaryOp.Lte;
                    break;
                case "Gte":
                    Op = BinaryOp.Gte;
                    break;
                case "And":
                    Op = BinaryOp.And;
                    break;
                case "Or":
                    Op = BinaryOp.Or;
                    break;
                default: throw new NotSupportedException($"Unsupported binary operation: {binaryOp}");
            }        
        }

        public Term Lhs { get; set; }
        public BinaryOp Op { get; set; }
        public Term Rhs { get; set; }
    }
}
