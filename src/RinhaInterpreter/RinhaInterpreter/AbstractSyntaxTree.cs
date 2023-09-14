using RinhaCompiler.Functions;
using RinhaCompiler.Models;
using RinhaInterpreter.Models;

namespace RinhaCompiler
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
