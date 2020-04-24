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

                case (byte)SymbolTable.Rectangle:
                    return new TinySvgRectangle(attributes);

                case (byte)SymbolTable.Line:
                    return new TinySvgLine(attributes);

                case (byte)SymbolTable.Polyline:
                    return new TinySvgPolyline(attributes);

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

                case "rect":
                    return new TinySvgRectangle(attributes);

                case "line":
                    return new TinySvgLine(attributes);

                case "polyline":
                    return new TinySvgPolyline(attributes);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
