using Newtonsoft.Json;
using RinhaInterpreter;
using System.Diagnostics;

//if (args.Length == 0)
//    throw new FileNotFoundException("Erro ao encontrar o arquivo da ast!");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

//string nomeArquivo = args[0];
string nomeArquivo = "json interno";

try
{
    //string json = File.ReadAllText(args[0]);
    var json = @"
{
    ""name"": ""var.rinha"",
    ""expression"": {
        ""kind"": ""Let"",
        ""name"": {
            ""text"": ""x"",
            ""location"": {
                ""start"": 4,
                ""end"": 5,
                ""filename"": ""var.rinha""
            }
        },
        ""value"": {
            ""kind"": ""Bool"",
            ""value"": true,
            ""location"": {
                ""start"": 8,
                ""end"": 10,
                ""filename"": ""var.rinha""
            }
        },
        ""next"": {
            ""kind"": ""Print"",
            ""value"": {
                ""kind"": ""Var"",
                ""text"": ""x"",
                ""location"": {
                    ""start"": 19,
                    ""end"": 20,
                    ""filename"": ""var.rinha""
                }
            },
            ""location"": {
                ""start"": 12,
                ""end"": 21,
                ""filename"": ""var.rinha""
            }
        },
        ""location"": {
            ""start"": 0,
            ""end"": 21,
            ""filename"": ""var.rinha""
        }
    },
    ""location"": {
        ""start"": 0,
        ""end"": 21,
        ""filename"": ""var.rinha""
    }
}";
    Console.WriteLine(json);
    dynamic arvore = JsonConvert.DeserializeObject(json);
    AbstractSyntaxTree ast = new AbstractSyntaxTree(arvore);

    Intepreter.Execute(ast.Expression, new Dictionary<string, KeyValuePair<string, object>>());

}
catch (FileNotFoundException fe)
{
    Console.WriteLine($"Erro ao encontrar o arquivo {nomeArquivo}");
}
catch (Exception e)
{
    Console.WriteLine("Erro ao executar o código da rinha: ", e.Message);
}

stopwatch.Stop();

Console.WriteLine("Interpreter Exec. Time: {0} ms", stopwatch.ElapsedMilliseconds);
//Console.WriteLine(args[0]);