using System.Collections.Generic;

namespace PlotterConversionSystem.IRTools
{
    /// <summary>
    /// The workaround class that enables the IToken implementations to allow
    /// their private attributes to be serialised.
    /// </summary>
    public class SerialiseObject
    {
        // Store the token ID.
        public byte tokenID { get; set; }

        // Store the paramater names and values.
        public Dictionary<string, string> attributes { get; set; }

        // Store the style names and values.  This is unused.
        public Dictionary<string, string> styleAttributes { get; set; }
    }
}
