using System;
using Newtonsoft.Json;

namespace ZendeskSell.LeadUnqualifiedReasons {
    public class LeadUnqualifiedReasonResponse {
        public LeadUnqualifiedReasonResponse(LeadUnqualifiedReasonResponse reason) : this() => ClassCopier.Copy(reason, this);
        public LeadUnqualifiedReasonResponse() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
