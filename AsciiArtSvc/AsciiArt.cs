using Figgle;
using System.Reflection;

namespace AsciiArtSvc;

public static class AsciiArt{
    public static string Write(string name, string? fontName = null){
        FiggleFont? font = null;
        if (!string.IsNullOrWhiteSpace(fontName))
        {
            font = typeof(FiggleFonts)
                .GetProperty(fontName, BindingFlags.Static | BindingFlags.Public)
                ?.GetValue(null) as FiggleFont;
        }

        font ??= FiggleFonts.Standard;

        return font.Render(name);
        
    }

    public static Lazy<IEnumerable<string>> AllFonts =
        new ( () =>
            from p in typeof(FiggleFonts)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
            select p.Name);
}