using FindText;
using CommandLine;
using CommandLine.Text;
// See https://aka.ms/new-console-template for more information

var results = Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(options => {
        WriteLine(options.Text);
    });

results.WithNotParsed(_ =>
    WriteLine(HelpText.RenderUsageText(results)));