using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.LineItems {
    public class LineItemRequest {
        public LineItemRequest(LineItemRequest source) : this() => ClassCopier.Copy(source, this);
        public LineItemRequest() { }

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
        public LineItemResponse(LineItemResponse source) : this() => ClassCopier.Copy(source, this);
        public LineItemResponse() : base() { }

        [JsonProperty("id")]
        public long ID { get; set; }
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
