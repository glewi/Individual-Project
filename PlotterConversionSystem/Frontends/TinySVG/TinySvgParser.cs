using System.Text.Json;
using PlotterConversionSystem.TokenDefinitions;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgParser
    {
        private const string path = @"IR.json";

        public static void Parse(IToken[] tokens)
        {
            JsonRoot jsonRoot;
            SerialiseObject serialiseObject;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            jsonRoot = new JsonRoot();
            jsonRoot.tokenarray = new SerialiseObject[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                IToken token = tokens[i];
                serialiseObject = new SerialiseObject();
                serialiseObject.tokenID = token.GetID();
                serialiseObject.attributes = token.GetNamedParameters();

                // Style information goes here...

                jsonRoot.tokenarray[i] = serialiseObject;
            }

            var Json = JsonSerializer.Serialize<JsonRoot>(jsonRoot, options);
            IRWriter.Write(Json, @path);
        }

        public static void Parse(IToken token)
        {
            SerialiseObject wrapper = new SerialiseObject();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var Json = JsonSerializer.Serialize(wrapper, options) + "\n";

            IRWriter.Write(Json, @path);
        }
    }
}
