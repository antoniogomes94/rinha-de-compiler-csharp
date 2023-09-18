using RinhaInterpreter.Functions;
using RinhaInterpreter.Models;

namespace RinhaInterpreter
{
    public class AbstractSyntaxTree
    {
        public string Name { get; set; }
        public Term Expression { get; set; }
        public Location Location { get; set; }

        public AbstractSyntaxTree(dynamic dynamicNode)
        {
            Name = dynamicNode.name;
            Location = new Location(dynamicNode.location);
            Expression = Generate(dynamicNode.expression);
        }

        private Term Generate(dynamic dynamicNode)
        {
            string kind = dynamicNode.kind;
            switch (kind)
            {
                case "Bool":
                    return new Bool
                    {
                        Kind = kind,
                        Value = dynamicNode.value,
                        Location = new Location(dynamicNode.location)
                    };
                case "Int":
                    return new Int
                    {
                        Kind = kind,
                        Value = dynamicNode.value,
                        Location = new Location(dynamicNode.location)
                    };
                case "Str":
                    return new Str
                    {
                        Kind = kind,
                        Value = dynamicNode.value,
                        Location = new Location(dynamicNode.location)
                    };
                case "Binary":
                    return new Binary(kind ,Generate(dynamicNode.lhs), dynamicNode.op.ToString(), Generate(dynamicNode.rhs), new Location(dynamicNode.location));
                case "Print":
                    return new Print
                    {
                        Kind = kind,
                        Value = Generate(dynamicNode.value),
                        Location = new Location(dynamicNode.location)
                    };
                default:
                    throw new NotSupportedException($"Unsupported node kind: {kind}");
            }
        }
    }
}
