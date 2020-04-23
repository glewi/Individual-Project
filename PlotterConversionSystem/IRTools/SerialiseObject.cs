using System.Collections.Generic;

namespace PlotterConversionSystem.IRTools
{
    public class SerialiseObject
    {
        public byte tokenID { get; set; }
        public Dictionary<string, string> attributes { get; set; }
        public Dictionary<string, string> styleAttributes { get; set; }
    }
}
