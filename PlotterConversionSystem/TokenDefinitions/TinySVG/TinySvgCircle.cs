using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    public class TinySvgCircle : IToken
    {
        private readonly byte tokenID = checked((byte)SymbolTable.Circle);
        private const ushort attributeCount = 3;
        private int x = 0, y = 0;
        private uint r = 0;

        public TinySvgCircle(params string[] attributes)
        {
            SetStringParameters(attributes);
        }

        public byte GetID()
        {
            return tokenID;
        }

        public Dictionary<string, string> GetNamedParameters()
        {
            return new Dictionary<string, string>
            {
                {"x", x.ToString()},
                {"y", y.ToString()},
                {"r", r.ToString()}
            };
        }

        public string[] GetParameters()
        {
            return new string[attributeCount]
            {
                x.ToString(),
                y.ToString(),
                r.ToString()
            };
        }

        public void SetStringParameters(params string[] parameters)
        {
            int.TryParse(parameters[0], out x);
            int.TryParse(parameters[1], out y);
            uint.TryParse(parameters[2], out r);
        }
    }
}
