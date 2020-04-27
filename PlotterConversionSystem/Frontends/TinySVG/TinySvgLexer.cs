using System;
using System.Linq;
using System.Xml.Linq;
using PlotterConversionSystem.TokenDefinitions;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgLexer
    {
        private static ITokenFactory factory = new TinySvgTokenFactory();

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
            // Create and empty array of tokens.
            IToken[] tokens = new IToken[elements.Length];

            // For each element in the elements array...
            for (int i = 0; i < elements.Length; i++)
            {
                // Create a copy of the element at i.
                XElement element = elements[i];

                // Store an array of the attributes associated with the XML element.
                XAttribute[] attributes = element.Attributes().ToArray();

                // Create an array to store these attributes as strings later.
                string[] parameterarray = new string[attributes.Length];

                // For each attribute in the element.
                for (int j = 0; j < attributes.Length; j++)
                {
                    // Assign the the paramaterarray to the value stored at the particular attribute.
                    parameterarray[j] = attributes[j].Value;
                }

                // If the element is not a comment
                if (!(element.Name.LocalName == "desc"))
                {
                    try
                    {
                        // Use the appropriate token factory to create an element using the read name, then
                        // populate that element using the parameterarray.
                        tokens[i] = factory.CreateToken(element.Name.LocalName, parameterarray);
                    }
                    catch(Exception exception)
                    {
                        // If there's an error, display it but continue interating through the file.
                        Console.WriteLine(exception.Message);
                    }
                }
            }
            return tokens;
        }
    }
}
