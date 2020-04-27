namespace PlotterConversionSystem.TokenDefinitions
{
    /// <summary>
    /// This is the interface that every token factory needs to implement.
    /// This allows for additional token factories to be subclasses as needed.
    /// </summary>
    public interface ITokenFactory
    {
        /// <summary>
        /// This method creates a TinySVG token.
        /// </summary>
        /// <param name="identifier">  </param>
        /// <param name="attributes"> The attributes is an array of attributes read from a TinySVG  </param>
        /// <returns></returns>
        IToken CreateToken(byte identifier, params string[] attributes);

        /// <summary>
        /// This method creates a TinySVG token.
        /// </summary>
        /// <param name="identifier"> The identifier is a string read from the TinySVG reader. </param>
        /// <param name="attributes"> The attributes is an array of attributes read from a TinySVG element </param>
        /// <returns></returns>
        IToken CreateToken(string identifier, params string[] attributes);
    }
}
