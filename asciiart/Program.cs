using AsciiArt;
using CommandLine;

// See https://aka.ms/new-console-template for more 

/*var opts = Parser.Default.ParseArguments<Options>(args);

WriteLine(opts);
*/

Parser.Default.ParseArguments<Options>(args)
 //.WithParsed(options => WriteLine(options.Text))
 .WithParsed<Options>(options => AsciiArts.Write(options.Text))
 .WithNotParsed(_ =>
   WriteLine("Usage: asciiart <text> --font QUALITY"));
