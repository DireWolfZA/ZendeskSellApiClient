using System;
using Newtonsoft.Json;

namespace ZendeskSell.Leads {
    public class LeadResponse : LeadRequest {
        public string GetLink() => $"https://app.futuresimple.com/leads/{ID}";

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
