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
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        void WriteFile(JsonRoot root, string @path);
    }
}
