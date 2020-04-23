using System.Xml.Linq;
using PlotterConversionSystem.TokenDefinitions;
using PlotterConversionSystem.Frontends.TinySVG;

namespace PlotterConversionSystem.Frontends
{
    public class TinySvgFrontend : IFrontend
    {


        public string[] Read(string @path)
        {
            return TinySvgReader.Read(@path);
        }

        public IToken[] Lex(string[] tokens)
        {
            var arr = new XElement[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                arr[i] = XElement.Parse(tokens[i]);
            }

            return TinySvgLexer.Lex(arr);
        }

        public void Parse(IToken[] tokens)
        {
            TinySvgParser.Parse(tokens);
        }
    }
}
