using System.IO;

namespace PlotterConversionSystem.IRTools
{
    /// <summary>
    /// This helper class is responsible for the writing of the
    /// intermediate representation JSON file.
    /// </summary>
    public static class IRWriter
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
        /// Writes a program string to a given file path.
        /// </summary>
        /// <param name="prog"> The program string to be written. </param>
        /// <param name="path">  The file path where it is to be written </param>
        public static void Write(string prog, string @path)
        {
            ClearFile(@path);
            File.WriteAllText(path, prog);
        }

        /// <summary>
        /// Writes an array of string statements to a file.
        /// </summary>
        /// <param name="prog"> The program string to be written. </param>
        /// <param name="path">  The file path where it is to be written </param>
        public static void Write(string[] prog, string @path)
        {
            if (!File.Exists(@path))
            {
                File.WriteAllLines(path, prog);
            }
            File.AppendAllLines(path, prog);
        }
    }
}
