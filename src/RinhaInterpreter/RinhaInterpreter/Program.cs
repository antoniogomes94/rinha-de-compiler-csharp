using Newtonsoft.Json;
using RinhaInterpreter;
using System.Diagnostics;

string json = @"
{
    ""name"": "".\\sum.rinha"",
    ""expression"": {
        ""kind"": ""Print"",
        ""value"": {
            ""kind"": ""Binary"",
            ""lhs"": {
                ""kind"": ""Int"",
                ""value"": 1,
                ""location"": {
                    ""start"": 7,
                    ""end"": 11,
                    ""filename"": "".\\sum.rinha""
                }
            },
            ""op"": ""Neq"",
            ""rhs"": {
                ""kind"": ""Int"",
                ""value"": 2,
                ""location"": {
                    ""start"": 15,
                    ""end"": 19,
                    ""filename"": "".\\sum.rinha""
                }
            },
            ""location"": {
                ""start"": 7,
                ""end"": 19,
                ""filename"": "".\\sum.rinha""
            }
        },
        ""location"": {
            ""start"": 0,
            ""end"": 20,
            ""filename"": "".\\sum.rinha""
        }
    },
    ""location"": {
        ""start"": 0,
        ""end"": 20,
        ""filename"": "".\\sum.rinha""
    }
}";

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

try
{
    dynamic arvore = JsonConvert.DeserializeObject(json);
    AbstractSyntaxTree ast = new AbstractSyntaxTree(arvore);
    Intepreter.Execute(ast.Expression);

}
catch (Exception e)
{
    Console.WriteLine("Erro ao executar o código da rinha: ", e.Message);
}

stopwatch.Stop();

Console.WriteLine("Interpreter Exec. Time: {0} ms", stopwatch.ElapsedMilliseconds);