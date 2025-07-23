using CommandLine;

namespace CrimeScene;

public record Options
{
    [Value(0, Required = true, HelpText = "Input File")]
    public string? InputFile { get; init; }

    [Value(1, Required = false, HelpText = "Output file")]
    public string? OutputFile { get; init; }

    [Option('c', "classification", HelpText = "Crime classification")]
    public string? Classification { get; init; } = "Murder";

}