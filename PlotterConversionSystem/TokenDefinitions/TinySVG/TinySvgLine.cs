using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    /// <summary>
    /// Represents a TinySVG line.
    /// </summary>
    public class TinySvgLine : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Line);

        // Store the XY coordiantes of the token.
        private int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

        /// <summary>
        /// The constructor for the TinySvgLine class.
        /// </summary>
        /// <param name="attributes"> A string[] of variable length. </param>
        public TinySvgLine(params string[] attributes)
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
                {"x1", x1.ToString()},
                {"y1", y1.ToString()},
                {"x2", x2.ToString()},
                {"y2", y2.ToString()}
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
                x1.ToString(),
                y1.ToString(),
                x2.ToString(),
                y2.ToString()
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
                x1 = int.Parse(parameters[0]);
                y1 = int.Parse(parameters[1]);
                x2 = int.Parse(parameters[2]);
                y2 = int.Parse(parameters[3]);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
