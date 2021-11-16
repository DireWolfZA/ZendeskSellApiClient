using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZendeskSell.Notes {
    public class NoteRequest {
        public NoteRequest(NoteRequest source) : this() => ClassCopier.Copy(source, this);
        public NoteRequest() {
            Tags = new string[] { };
        }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public int ResourceID { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("is_important")]
        public bool IsImportant { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
