using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    public interface IWriter
    {
        string BuildFile(JsonRoot root);
    }
}
