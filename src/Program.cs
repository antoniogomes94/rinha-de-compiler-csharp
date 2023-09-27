using Newtonsoft.Json;
using RinhaInterpreter;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

string arquivo = args.Length > 0 ? args[0] : "/var/rinha/source.rinha.json"; ;
Console.WriteLine(arquivo);
try
{
    string json = File.ReadAllText(args[0]);
    dynamic arvore = JsonConvert.DeserializeObject(json);

    AbstractSyntaxTree ast = new AbstractSyntaxTree(arvore);

    Intepreter.Execute(ast.Expression, new Dictionary<string, KeyValuePair<string, object>>());

}
catch (FileNotFoundException fe)
{
    Console.WriteLine($"Erro ao encontrar o arquivo {arquivo}");
}
catch (Exception e)
{
     Console.WriteLine("Erro ao executar o código da rinha: ", e.Message);
}

stopwatch.Stop();

Console.WriteLine("Interpreter Exec. Time: {0} ms", stopwatch.ElapsedMilliseconds);