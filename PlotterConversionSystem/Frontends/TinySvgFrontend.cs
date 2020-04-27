using System.Xml.Linq;
using PlotterConversionSystem.TokenDefinitions;
using PlotterConversionSystem.Frontends.TinySVG;
using System;

namespace PlotterConversionSystem.Frontends
{
    /// <summary>
    /// The class responsible for managing the TinySVGFrontend methods.
    /// </summary>
    public class TinySvgFrontend : IFrontend
    {
        /// <summary>
        /// Reads a program statements from a given path and returns them.
        /// </summary>
        /// <param name="path">  The file path to read. </param>
        /// <returns></returns>
        public string[] Read(string @path)
        {
            return TinySvgReader.Read(@path);
        }

        /// <summary>
        /// Performas lexical analysis on the given program statements.
        /// </summary>
        /// <param name="statements"> The statements read by the associated reader class. </param>
        /// <returns> An array of ITokens that represent the program statements. </returns>
        public IToken[] Lex(string[] statements)
        {
            // If the statements are empty.
            if (statements == null)
            {
                throw new ArgumentNullException();
            }

            // Create a new array of XML elements.
            var arr = new XElement[statements.Length];

            // For every statment.
            for (int i = 0; i < statements.Length; i++)
            {
                // Store the statement as an XML element object.
                arr[i] = XElement.Parse(statements[i]);
            }

            // Pass it to the lexer and then return it.
            return TinySvgLexer.Lex(arr);
        }

        /// <summary>
        /// Parse the tokens to an intermediate representation
        /// </summary>
        /// <param name="tokens">  The tokens that are to be parsed. </param>
        public void Parse(IToken[] tokens)
        {
            // Call the associated parser.
            TinySvgParser.Parse(tokens);
        }
    }
}
