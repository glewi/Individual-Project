using System.IO;
using PlotterConversionSystem.IRTools;
using PlotterConversionSystem.Frontends;
using PlotterConversionSystem.Backends;
using System;
using System.Runtime.CompilerServices;
using PlotterConversionSystem.TokenDefinitions.TinySVG;

namespace PlotterConversionSystem
{
    /// <summary>
    /// The entry point for the system.  It utilises a facade design pattern that simplifies
    /// the creation of the system object.
    /// </summary>
    public static class CompilerFaçade
    {
        // Measures if the compilation process was succesfull.
        private static bool SuccessFlag = true;
        
        /// <summary>
        /// Validates if the provided path exists.
        /// </summary>
        /// <param name="path"> The path that the program is trying to write. </param>
        private static void ValidatePath(string @path)
        {
            // If the file does not exist.
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// The main method that the system performs.  It is responsible for directing the 
        /// operation of the entire compiler.
        /// </summary>
        /// <param name="input"> The input path that needs to be used. </param>
        /// <param name="output" The output path that needs to be used. ></param>
        /// <returns></returns>
        public static bool Compile(string @input, string @output)
        {
            // Try to validate that input path.
            try
            {
                ValidatePath(@input);
            }
            catch (FileNotFoundException exception)
            {
                // Show the exception and return with a flag of false.
                Console.WriteLine(exception);
                return SuccessFlag;
            }

            // Instantiate the frontend and backends for the compiler,
            // this is where a programmer would add their own implementations.
            IFrontend frontend = new TinySvgFrontend();
            IBackend backend = new HpglBackend();

            // Get the statements from the input file using the appropriate reader.
            var statements = frontend.Read(input);
            
            // Tokenise the statements.
            var lexemes = frontend.Lex(statements);
            
            // Parse the tokens to an intermediate representation.
            frontend.Parse(lexemes);

            // Read the tokens from the IR file and pass it to the appropriate
            // backend writer file.
            JsonRoot s = IRReader.Read();
            backend.WriteFile(s, output);
            
            // If all this has happened with no errors set the successflag to true.
            SuccessFlag = true;
            return SuccessFlag;
        }
    }
}
