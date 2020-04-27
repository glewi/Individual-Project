using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    /// <summary>
    /// Represents a TinySVG ellipse.
    /// </summary>
    public class TinySvgEllipse : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Ellipse);
        
        // Store the XY coordinates of the token.
        private int Cx = 0, Cy = 0;

        // Store XY radius-axis of the token.
        private uint Rx = 0, Ry = 0;

        /// <summary>
        /// The constructor for the TinySvgEllipse class.
        /// </summary>
        /// <param name="attributes"> A string[] of variable length. </param>
        public TinySvgEllipse(params string[] attributes)
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
                {"cx", Cx.ToString() },
                {"cy", Cx.ToString() },
                {"rx", Cx.ToString() },
                {"rx", Cx.ToString() },

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
                Cx.ToString(),
                Cy.ToString(),
                Rx.ToString(),
                Ry.ToString()
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
                Cx = int.Parse(parameters[0]);
                Cy = int.Parse(parameters[1]);

                // Use the checked function to mitigate against integer overflows/underflows.
                Rx = checked(uint.Parse(parameters[2]));
                Ry = checked(uint.Parse(parameters[2]));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
