namespace PlotterConversionSystem.TokenDefinitions
{
    public interface ITokenFactory
    {
        IToken CreateToken(byte identifier, params string[] attributes);
        IToken CreateToken(string identifier, params string[] attributes);
    }
}
