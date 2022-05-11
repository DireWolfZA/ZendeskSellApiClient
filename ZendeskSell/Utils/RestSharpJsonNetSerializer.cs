using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace ZendeskSell.Utils {
    /// <summary>
    /// Default JSON serializer for request bodies
    /// <br/>Doesn't currently use the <see cref="SerializeAsAttribute"/>, defers to Newtonsoft's attributes
    /// </summary>
    public class RestSharpJsonNetSerializer : ISerializer {
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Default serializer
        /// </summary>
        public RestSharpJsonNetSerializer(bool includeNullValues = true) {
            ContentType = "application/json";
            _serializer = new JsonSerializer {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = includeNullValues ? NullValueHandling.Include : NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
            };
        }

        /// <summary>
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        public RestSharpJsonNetSerializer(JsonSerializer serializer) {
            ContentType = "application/json";
            _serializer = serializer;
        }

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj) {
            using (var stringWriter = new StringWriter()) {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter)) {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}
