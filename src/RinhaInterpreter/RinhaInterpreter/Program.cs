using Newtonsoft.Json;
using RinhaInterpreter;
using System.Diagnostics;

if (args.Length == 0)
    throw new FileNotFoundException("Erro ao encontrar o arquivo da ast!");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

string arquivo = args[0];

try
{
    Console.WriteLine(arquivo);
    dynamic arvore = JsonConvert.DeserializeObject(arquivo);
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
//Console.WriteLine(args[0]);