using AsciiArtSvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (int? skip, int? take) => 
    AsciiArt.AllFonts.Value
        .Skip(skip ?? 0)
        .Take(take ?? 100));

app.MapGet("/{text}", (string text, string? font) => AsciiArt.Write(text, font));

app.Run();
