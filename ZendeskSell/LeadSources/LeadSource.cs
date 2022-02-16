using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.LeadSources {
    public class LeadSourceRequest {
        public LeadSourceRequest(LeadSourceRequest source) : this() => ClassCopier.Copy(source, this);
        public LeadSourceRequest() { }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }

    public class LeadSourceResponse : LeadSourceRequest {
        public LeadSourceResponse(LeadSourceResponse source) : this() => ClassCopier.Copy(source, this);
        public LeadSourceResponse() : base() { }

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
