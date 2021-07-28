using System;
using Newtonsoft.Json;

namespace ZendeskSell.Orders {
    public class OrderRequest {
        [JsonProperty("deal_id")]
        public int? DealID { get; set; }
        [JsonProperty("discount")]
        public int? Discount { get; set; }
    }

    public class OrderResponse : OrderRequest {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
