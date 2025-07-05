using Figgle;

namespace AsciiArt;

public static class AsciiArts{
    public static void Write(string text){
        WriteLine(FiggleFonts.Standard.Render(text));
        WriteLine("Brought to you by " + typeof(AsciiArts).FullName);
    }
}