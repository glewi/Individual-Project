using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    /// <summary>
    /// Represents a TinySVG circle.
    /// </summary>
    public class TinySvgCircle : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Circle);
        
        // Store the XY coordiantes of the token.
        private int x = 0, y = 0;

        // Store the radius of the token.
        private uint r = 0;

        /// <summary>
        /// The constructor for the TinySvgCircle class.
        /// </summary>
        /// <param name="attributes"> A string[] of variable length. </param>
        public TinySvgCircle(params string[] attributes)
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
                {"x", x.ToString()},
                {"y", y.ToString()},
                {"r", r.ToString()}
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
                r.ToString()
            };
        }

        /// <summary>
        /// Assigns the attributes of the token to a given string array.
        /// </summary>
        /// <param name="parameters"> A <code>string[]</code> of variable length. </param>
        public void SetParameters(params string[] parameters)
        {
            try
            {
                x = int.Parse(parameters[0]);
                y = int.Parse(parameters[1]);
                
                // Use the checked function to mitigate against integer overflows/underflows.
                r = checked(uint.Parse(parameters[2]));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
