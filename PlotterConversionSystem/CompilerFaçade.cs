using System.IO;
using PlotterConversionSystem.IRTools;
using PlotterConversionSystem.Frontends;
using PlotterConversionSystem.Backends;
using System;
using System.Runtime.CompilerServices;
using PlotterConversionSystem.TokenDefinitions.TinySVG;

namespace PlotterConversionSystem
{
    public static class CompilerFaçade
    {
        private static bool SuccessFlag = true;
        
        private static void ValidatePath(string @path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
        }

        public static bool Compile(string @input, string @output)
        {
            try
            {
                ValidatePath(@input);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception);
                return SuccessFlag;
            }

            IFrontend frontend = new TinySvgFrontend();
            IBackend backend = new HpglBackend();

            var prog = frontend.Read(input);
            var lexemes = frontend.Lex(prog);
            frontend.Parse(lexemes);

            JsonRoot s = IRReader.Read();
            backend.WriteFile(s, output);
            
            SuccessFlag = true;
            return SuccessFlag;
        }
    }
}
