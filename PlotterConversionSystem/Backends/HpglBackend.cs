using System.IO;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    /// <summary>
    /// This backend implementation acts the the director
    /// for the HPGL output.
    /// </summary>
    public class HpglBackend : IBackend
    {
        /// <summary>
        /// The ClearFile method deletes the contents of a given file.
        /// </summary>
        /// <param name="path">The path of the file that is to be cleared.</param>
        private static void ClearFile(string @path)
        {
            File.Delete(@path);
        }

        /// <summary>
        /// The WriteFile method writes the contents of a given file.
        /// </summary>
        /// <param name="root"> The root object is the JsonRoot item that commands are to be genereted from. </param>
        /// <param name="path"> The path object is the location where the file is to be written. </param>
        public void WriteFile(JsonRoot root, string @path)
        {
            // Instansiate a new HPGLWriter and use it to create a file.
            HPGLWriter writer = new HPGLWriter();
            string towrite = writer.BuildFile(root);

            // If the file already exists clear it, then write the new one.
            ClearFile(@path);
            File.WriteAllText(path, towrite);
        }
    }
}
