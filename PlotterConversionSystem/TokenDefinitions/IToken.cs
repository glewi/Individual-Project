using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions
{
    /// <summary>
    /// The interface that represents each token that is implemented.
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Return the token ID (0-255)
        /// </summary>
        byte GetID();
        /// <summary>
        /// Get the token parameters and its associated name.
        /// </summary>
        /// <returns>Returns a dictionary of string,string which correlates to 'parametername, value'</returns>
        Dictionary<string, string> GetNamedParameters();

        /// <summary>
        /// Get a list of parameters from the token.
        /// </summary>
        /// <returns> Returns a string array of parameters from the token. </returns>
        string[] GetParameters();

        /// <summary>
        /// Set the token parameters.
        /// </summary>
        /// <param name="parameters"> An array of the token parameters </param>
        void SetParameters(params string[] parameters);
    }
}
