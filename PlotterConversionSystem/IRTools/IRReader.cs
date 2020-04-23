using System.IO;
using System.Text.Json;

namespace PlotterConversionSystem.IRTools
{
    public static class IRReader
    {
        static string filepath = @"IR.json";

        public static JsonRoot Read()
        {
            StreamReader reader = new StreamReader(filepath);

            var prog = reader.ReadToEnd();
            reader.Close();

            JsonRoot json = JsonSerializer.Deserialize<JsonRoot>(prog);
            return json;
        }
    }
}
