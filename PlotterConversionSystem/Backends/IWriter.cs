using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    public interface IWriter
    {
        string buildFile(JsonRoot root);
    }
}
