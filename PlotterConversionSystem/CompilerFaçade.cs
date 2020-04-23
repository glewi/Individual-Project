using System.IO;
using PlotterConversionSystem.IRTools;
using PlotterConversionSystem.Frontends;
using PlotterConversionSystem.Backends;

namespace PlotterConversionSystem
{
    public static class CompilerFaçade
    {
        private static void ValidatePath(string @path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
        }

        public static void Compile(string @input, string @output)
        {
            ValidatePath(@input);
            ValidatePath(@output);

            IFrontend frontend = new TinySvgFrontend();
            IBackend backend = new HpglBackend();

            var prog = frontend.Read(input);
            var lexemes = frontend.Lex(prog);
            frontend.Parse(lexemes);

            JsonRoot s = IRReader.Read();
            backend.WriteFile(s, output);
        }
    }
}
