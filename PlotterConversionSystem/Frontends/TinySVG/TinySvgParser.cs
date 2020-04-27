using System.Text.Json;
using PlotterConversionSystem.TokenDefinitions;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    /// <summary>
    /// The class responsible for parsing the TinySVG intermediate representation.
    /// </summary>
    public static class TinySvgParser
    {
        // The default path.
        private const string path = @"IR.json";

        /// <summary>
        /// Parse a given array of tokens.
        /// </summary>
        /// <param name="tokens">The tokens to be parsed.</param>
        public static void Parse(IToken[] tokens)
        {
            JsonRoot jsonRoot;
            SerialiseObject serialiseObject;

            // Set the Json intentation option to true.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Instansiate a jsonroot object and set its internal array of tokens
            // to the number of tokens passed to it.
            jsonRoot = new JsonRoot();
            jsonRoot.tokenarray = new SerialiseObject[tokens.Length];

            // For each token.
            for (int i = 0; i < tokens.Length; i++)
            {
                // If it is not null
                if (tokens[i] != null)
                {
                    // Set the serialiseObject to the values stored in the token.
                    IToken token = tokens[i];
                    serialiseObject = new SerialiseObject();
                    serialiseObject.tokenID = token.GetID();
                    serialiseObject.attributes = token.GetNamedParameters();

                    // Style information goes here...

                    // Add the serialiseObject representation of the token to the JsonRoot object.
                    jsonRoot.tokenarray[i] = serialiseObject;
                }
            }

            // Serialise the JsonRoot object and write it.
            var Json = JsonSerializer.Serialize<JsonRoot>(jsonRoot, options);
            IRWriter.Write(Json, @path);
        }

        /// <summary>
        /// Serialise a single token.
        /// </summary>
        /// <param name="token"></param>
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
