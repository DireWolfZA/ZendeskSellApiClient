using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Leads {
    public class LeadResponse : LeadRequest {
        public LeadResponse(LeadResponse source) : this() => ClassCopier.Copy(source, this);
        public LeadResponse() : base() { }
        public string GetLink() => $"https://app.futuresimple.com/leads/{ID}";

        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
