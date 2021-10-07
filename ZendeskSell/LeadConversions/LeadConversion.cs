using System;
using Newtonsoft.Json;

namespace ZendeskSell.LeadConversions {
    public class LeadConversionRequest {
        [JsonProperty("lead_id")]
        public int LeadID { get; set; }
        [JsonProperty("owner_id")]
        public int? OwnerID { get; set; }
        [JsonProperty("create_deal")]
        public bool CreateDeal { get; set; }
    }

    public class LeadConversionResponse {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("lead_id")]
        public int LeadID { get; set; }
        [JsonProperty("individual_id")]
        public int? IndividualID { get; set; }
        [JsonProperty("organization_id")]
        public int? OrganizationID { get; set; }
        [JsonProperty("deal_id")]
        public int? DealID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
