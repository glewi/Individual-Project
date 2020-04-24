using System;
using System.Collections.Generic;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    /// <summary>
    /// Represents a TinySVG rectangle.
    /// </summary>
    public class TinySvgRectangle : IToken
    {
        // The token ID generated at object instantiation. Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Rectangle);
        
        // Store the XY coordinates, and the width and height of the token.
        private int x = 0, y = 0, width = 0, height = 0;

        // Store the radius of the corners of the rectangle if it rounded, 
        // default to 0 if not used.
        private uint rx = 0, ry = 0;

        /// <summary>
        /// The constructor for the <code>TinySvgRectangle</code> class.
        /// </summary>
        /// <param name="attributes"> A <code>string[]</code> of variable length. </param>
        public TinySvgRectangle(params string[] attributes)
        {
            SetStringParameters(attributes);
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
                {"x", x.ToString()},
                {"y", y.ToString()},
                {"width", width.ToString() },
                {"height", height.ToString() },
                {"rx", rx.ToString()},
                {"ry", ry.ToString()}
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
                x.ToString(),
                y.ToString(),
                width.ToString(),
                height.ToString(),
                rx.ToString(),
                ry.ToString()
            };
        }

        /// <summary>
        /// Assigns the attributes of the token to a given string array.
        /// </summary>
        /// <param name="parameters"> A <code>string[]</code> of variable length </param>
        public void SetStringParameters(params string[] parameters)
        {
            // Check for any errors when parsing the int values from the given strings.
            try
            {
                // Parse integers from the given strings, throws an InvalidCastException otherwise.
                x = int.Parse(parameters[0]);
                y = int.Parse(parameters[1]);
                width = int.Parse(parameters[2]);
                height = int.Parse(parameters[3]);

                // Use a checked block to validate against invalid integers passed to the Uint.
                // Should throw an OverflowException if the parsed integers are invalid.
                rx = checked(uint.Parse(parameters[4]));
                ry = checked(uint.Parse(parameters[5]));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
