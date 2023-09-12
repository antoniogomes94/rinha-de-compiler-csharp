using Newtonsoft.Json;
using RinhaCompiler;
using System.Diagnostics;

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
    dynamic arvore = JsonConvert.DeserializeObject(json);
    AbstractSyntaxTree ast = new AbstractSyntaxTree(arvore);
    ast.Interpret();

}
catch (Exception e)
{
    Console.WriteLine("Erro ao executar o código da rinha: ", e.Message);
}

stopwatch.Stop();

Console.WriteLine("Interpreter Exec. Time: {0} ms", stopwatch.ElapsedMilliseconds);