using AsciiArt;
using CommandLine;

// See https://aka.ms/new-console-template for more 


Parser.Default.ParseArguments<Options>(args)
 .WithParsed<Options>(AsciiArts.Write)
 .WithNotParsed(_ =>
   WriteLine("Usage: asciiart <text> --font QUALITY"));