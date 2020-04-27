using System;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBackend
    {
        /// <summary>
        /// The interface that represents the methods that a backend should implement.  Currently
        /// only contains the WriteFile method, which takes a JsonRoot object and a file path for the output.
        /// </summary>
        /// <param name="root"> The program that is to be written, in the form of a JsonRoot object </param>
        /// <param name="path"> The path that the final output should be stored at </param>
        void WriteFile(JsonRoot root, string @path);
    }
}
