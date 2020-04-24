using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG
{
    public class TinySvgEllipse : IToken
    {
        // The token ID generated at object instantiation.  Cannot be changed, only read.
        private readonly byte tokenID = checked((byte)SymbolTable.Ellipse);

        public byte GetID()
        {
            return tokenID;
        }

        public Dictionary<string, string> GetNamedParameters()
        {
            throw new NotImplementedException();
        }

        public string[] GetParameters()
        {
            throw new NotImplementedException();
        }

        public void SetStringParameters(params string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
