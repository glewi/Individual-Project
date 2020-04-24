using System.IO;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    /// <summary>
    /// 
    /// </summary>
    public class HpglBackend : IBackend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private static void ClearFile(string @path)
        {
            File.Delete(@path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="path"></param>
        public void WriteFile(JsonRoot root, string @path)
        {
            HPGLWriter writer = new HPGLWriter();
            string towrite = writer.BuildFile(root);

            ClearFile(@path);
            File.WriteAllText(path, towrite);
        }
    }
}
