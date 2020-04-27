using System.Runtime.Remoting.Channels;

namespace PlotterConversionSystem.IRTools
{
    /// <summary>
    /// The JsonRoot object only exists because the JSON language
    /// requires a root level object.  So this simply stores a list of
    /// serialiseObjects that are to be written and read from the intermediate
    /// representation.
    /// </summary>
    public class JsonRoot
    {
        // An array of serialiseObjects that effectively encapsulate
        // the IToken objects created by the frontend.lex methods.
        public SerialiseObject[] tokenarray { get; set; }
    }
}
