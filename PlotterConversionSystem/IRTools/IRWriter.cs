using System.IO;

namespace PlotterConversionSystem.IRTools
{
    public static class IRWriter
    {
        private const string path = @"IR.json";

        private static void ClearFile(string @path)
        {
            File.Delete(@path);
        }

        public static void Write(string prog, string @path)
        {
            ClearFile(@path);
            File.WriteAllText(path, prog);
        }

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
