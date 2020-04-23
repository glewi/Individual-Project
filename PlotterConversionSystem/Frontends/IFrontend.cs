using PlotterConversionSystem.TokenDefinitions;

namespace PlotterConversionSystem.Frontends
{
    public interface IFrontend
    {
        string[] Read(string input);
        IToken[] Lex(string[] tokens);
        void Parse(IToken[] tokens);
    }
}
