using Newtonsoft.Json;
using RinhaInterpreter;
using System.Diagnostics;

string jsonHello = @"
{
    ""name"": ""hello.rinha"",
    ""expression"": {
        ""kind"": ""Print"",
        ""value"": {
            ""kind"": ""Str"",
            ""value"": ""Hello World!"",
            ""location"": {
                ""start"": 7,
                ""end"": 20,
                ""filename"": ""hello.rinha""
            }
        },
        ""location"": {
            ""start"": 0,
            ""end"": 21,
            ""filename"": ""hello.rinha""
        }
    },
    ""location"": {
            ""start"": 0,
            ""end"": 21,
            ""filename"": ""hello.rinha""
        }
}";

string jsonSum = @"
{
    ""name"": "".\\sum.rinha"",
    ""expression"": {
        ""kind"": ""Print"",
        ""value"": {
            ""kind"": ""Binary"",
            ""lhs"": {
                ""kind"": ""Int"",
                ""value"": 10,
                ""location"": {
                    ""start"": 7,
                    ""end"": 8,
                    ""filename"": "".\\sum.rinha""
                }
            },
            ""op"": ""Add"",
            ""rhs"": {
                ""kind"": ""Str"",
                ""value"": 3,
                ""location"": {
                    ""start"": 11,
                    ""end"": 12,
                    ""filename"": "".\\sum.rinha""
                }
            },
            ""location"": {
                ""start"": 7,
                ""end"": 12,
                ""filename"": "".\\sum.rinha""
            }
        },
        ""location"": {
            ""start"": 0,
            ""end"": 13,
            ""filename"": "".\\sum.rinha""
        }
    },
    ""location"": {
        ""start"": 0,
        ""end"": 13,
        ""filename"": "".\\sum.rinha""
    }
}";

string json = @"
{
    ""name"": ""hello.rinha"",
    ""expression"": {
        ""kind"": ""Print"",
        ""value"": {
            ""kind"": ""Str"",
            ""value"": ""Hello World!"",
            ""location"": {
                ""start"": 7,
                ""end"": 20,
                ""filename"": ""hello.rinha""
            }
        },
        ""location"": {
            ""start"": 0,
            ""end"": 21,
            ""filename"": ""hello.rinha""
        }
    },
    ""location"": {
            ""start"": 0,
            ""end"": 21,
            ""filename"": ""hello.rinha""
        }
}";

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

try
{
    dynamic arvore = JsonConvert.DeserializeObject(jsonSum);
    AbstractSyntaxTree ast = new AbstractSyntaxTree(arvore);
    Intepreter.Execute(ast.Expression);

}
catch (Exception e)
{
    Console.WriteLine("Erro ao executar o código da rinha: ", e.Message);
}

stopwatch.Stop();

Console.WriteLine("Interpreter Exec. Time: {0} ms", stopwatch.ElapsedMilliseconds);