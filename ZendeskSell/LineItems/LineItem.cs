using System;
using Newtonsoft.Json;

namespace ZendeskSell.LineItems {
    public class LineItemRequest {
        [JsonProperty("product_id")]
        public int? ProductID { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("variation")]
        public string Variation { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    public class LineItemResponse : LineItemRequest {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sku")]
        public string SKU { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
