using System;
using PlotterConversionSystem.TokenDefinitions.TinySVG;

namespace PlotterConversionSystem.TokenDefinitions
{
    /// <summary>
    /// This concrete token factory is used to generate TinySVG tokens for the rest of the project.
    /// </summary>
    public class TinySvgTokenFactory : ITokenFactory
    {
        // Create a token using the byte identifier and its read attributes.
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

                case (byte)SymbolTable.Polygon:
                    return new TinySvgPolygon(attributes);

                default:
                    throw new NotImplementedException();
            }
        }

        // Create the token using the string identifier of its name and its associated attributes
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

                case "polygon":
                    return new TinySvgPolygon(attributes);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
