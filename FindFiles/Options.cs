using CommandLine;

namespace FindFiles;

public record Options
{
    [Value(0, Required = true, HelpText = "Root Folder")]
    public string RootFolder { get; init; } = ".";

    [Value(1, Required = true, HelpText = "File Name")]
    public string Filter { get; init; } = "*";

    [Option('r', "recurse", HelpText = "Search subfolder recursively")]
    public bool Recursive { get; init; } = false;
}