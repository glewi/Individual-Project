using System;
using PlotterConversionSystem.TokenDefinitions.TinySVG;

namespace PlotterConversionSystem.TokenDefinitions
{
    public class TinySvgTokenFactory : ITokenFactory
    {
        public IToken CreateToken(byte identifier, params string[] attributes)
        {
            switch (identifier)
            {
                case (byte)SymbolTable.Circle:
                    return new TinySvgCircle(attributes);

                default:
                    throw new NotImplementedException();
            }
        }

        public IToken CreateToken(string identifier, params string[] attributes)
        {
            switch (identifier)
            {
                case "circle":
                    return new TinySvgCircle(attributes);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
