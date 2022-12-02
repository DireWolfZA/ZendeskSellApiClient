using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Documents {
    public class DocumentResponse {
        public DocumentResponse(DocumentResponse source) : this() => ClassCopier.Copy(source, this);
        public DocumentResponse() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public int ResourceID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("download_url")]
        public string DownloadURL { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
