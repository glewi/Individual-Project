using System;
using System.Linq;
using System.Xml.Linq;
using PlotterConversionSystem.TokenDefinitions;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgLexer
    {
        private static ITokenFactory factory = new TinySvgTokenFactory();
        
        private static void LexCanvasOptions(XElement[] elements)
        {

        }

        private static void LexAttribute(XAttribute attributes)
        {

        }

        /// <summary>
        /// Lex an array of XElements.
        /// </summary>
        /// <param name="elements">
        /// An array of XElement retreived from LINQ.
        /// </param>
        /// <returns>
        /// An IToken array of the passed XElement array.
        /// </returns>
        public static IToken[] Lex(XElement[] elements)
        {
            IToken[] tokens = new IToken[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                XElement element = elements[i];
                Console.WriteLine(element.Name.LocalName);
                XAttribute[] attributes = element.Attributes().ToArray();
                string[] parameterarray = new string[attributes.Length];

                for (int j = 0; j < attributes.Length; j++)
                {
                    parameterarray[j] = attributes[j].Value;
                }

                if (!(element.Name.LocalName == "desc"))
                {
                    tokens[i] = factory.CreateToken(element.Name.LocalName, parameterarray);
                }
            }
            return tokens;
        }
    }
}
