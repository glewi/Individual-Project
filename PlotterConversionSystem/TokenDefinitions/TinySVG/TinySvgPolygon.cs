using System;
using System.Collections.Generic;
using System.Text;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    /// <summary>
    /// Represents a TinySVGPolygon.
    /// </summary>
    public class TinySvgPolygon : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Polygon);
        
        // Represents the tinySVG path data.
        private string path = null;

        /// <summary>
        /// Strip any uneccessary spaces from the path.
        /// </summary>
        /// <param name="path"> Te path attribute to be parsed. </param>
        /// <returns></returns>
        private string ParsePath(string path)
        {
            // Use a string builder for performance.
            StringBuilder builder = new StringBuilder();

            try
            {
                foreach (char c in path)
                {
                    // If it is not a space.
                    if (c != ' ')
                    {
                        builder.Append(c);
                    }
                    // Otherwise if it and the next character is not a space
                    else if (c == ' ' && c + 1 != ' ')
                    {
                        builder.Append(c);
                    }
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
            return builder.ToString();
        }

        /// <summary>
        /// The constructor for the TinySvgPolygon class.
        /// </summary>
        /// <param name="attributes"> A string[] of variable length. </param>
        public TinySvgPolygon(params string[] attributes)
        {
            SetParameters(attributes);
        }

        /// <summary>
        /// Returns the token ID that is assigned to the token at creation.
        /// </summary>
        /// <returns>The byte ID of the token.</returns>
        public byte GetID()
        {
            return tokenID;
        }

        /// <summary>
        /// Returns a list of keys and values representing the attributes of the token.
        /// </summary>
        /// <returns>
        /// Returns a <code> Dictionary<string,string> </code> containing
        /// the names of the attributes followed by their values.
        /// </returns>
        public Dictionary<string, string> GetNamedParameters()
        {
            return new Dictionary<string, string>
            {
                {"path", path }
            };
        }

        /// <summary>
        /// Returns a string array containing all token attributes.
        /// </summary>
        /// <returns> A <code>string[]</code> of all attributes.
        /// </returns>
        public string[] GetParameters()
        {
            return new string[]
            {
                path.ToString()
            };
        }

        /// <summary>
        /// Assigns the attributes of the token to a given string array.
        /// </summary>
        /// <param name="parameters"> A string[] of variable length. </param>
        public void SetParameters(params string[] parameters)
        {
            try
            {
                path = ParsePath(parameters[0]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
