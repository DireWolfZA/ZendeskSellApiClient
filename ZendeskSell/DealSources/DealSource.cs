using System;
using Newtonsoft.Json;

namespace ZendeskSell.DealSources {
    public class DealSourceRequest {
        public DealSourceRequest(DealSourceRequest source) : this() => ClassCopier.Copy(source, this);
        public DealSourceRequest() { }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }

    public class DealSourceResponse : DealSourceRequest {
        public DealSourceResponse(DealSourceResponse source) : this() => ClassCopier.Copy(source, this);
        public DealSourceResponse() : base() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
