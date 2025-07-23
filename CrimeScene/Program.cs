using CrimeScene;
using CommandLine;
using CommandLine.Text;
using System.Text;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information

static void FindWithJsonDom(Stream inStream, Stream outstream, string classification)
{
    using var writer = new StreamWriter(outstream, Encoding.UTF8, leaveOpen: true);

    using var jsonDoc = JsonDocument.Parse(inStream);

    foreach (var jokeElement in jsonDoc.RootElement.EnumerateArray())
    {
        string? type = jokeElement.GetProperty("type").GetString();

        if (String.Equals(classification, type, StringComparison.OrdinalIgnoreCase))
        {
            writer.WriteLine(jokeElement.GetRawText());
        }
    }
}

var results = Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(options =>
    {
        var inFile = new FileInfo(options.InputFile!);
        if (!inFile.Exists)
        {
            Console.Error.WriteLine($"{inFile.FullName} does not exist.");
            return;
        }

        using var inStream = inFile.OpenRead();

        FileInfo? outFile = null;
        if (options.OutputFile != null)
        {
            outFile = new FileInfo(options.OutputFile);

            if (outFile.Exists)
            {
                outFile.Delete();
            }
        }

        using var outStream = outFile != null ? outFile.OpenWrite() : Console.OpenStandardOutput();

        FindWithJsonDom(inStream, outStream, options.Classification);
    });

results.WithNotParsed(_ =>
    WriteLine(HelpText.RenderUsageText(results)));