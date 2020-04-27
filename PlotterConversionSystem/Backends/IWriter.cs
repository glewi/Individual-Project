using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{

    /// <summary>
    /// The itnerface that an output writer should implement.  This is used so developers
    /// could add writers that work in different ways than the currently implemented HPGL writer.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// This method takes a JsonRoot representation of a program and uses it to build a file
        /// of the commands that need to be written.
        /// </summary>
        /// <param name="root">  The program that is to be operated on. </param>
        /// <returns></returns>
        string BuildFile(JsonRoot root);
    }
}
