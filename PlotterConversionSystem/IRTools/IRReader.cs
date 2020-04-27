using System.IO;
using System.Text.Json;

namespace PlotterConversionSystem.IRTools
{
    /// <summary>
    /// This helper class is responsible for the reading of the intermdiate
    /// representation JSON file.
    /// </summary>
    public static class IRReader
    {
        // The default filepath for the IR file.
        static string filepath = @"IR.json";

        /// <summary>
        /// Read the file contained at the deault filepath.
        /// </summary>
        /// <returns></returns>
        public static JsonRoot Read()
        {
            // Create a new streamreader.
            StreamReader reader = new StreamReader(filepath);

            // Read and close the file.
            var prog = reader.ReadToEnd();
            reader.Close();

            // Populate a new JsonRoot object using what was read from the intermediate
            // representation file and return it.
            JsonRoot json = JsonSerializer.Deserialize<JsonRoot>(prog);
            return json;
        }
    }
}
