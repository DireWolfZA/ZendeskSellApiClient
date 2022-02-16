using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Orders {
    public class OrderRequest {
        public OrderRequest(OrderRequest source) : this() => ClassCopier.Copy(source, this);
        public OrderRequest() { }

        [JsonProperty("deal_id")]
        public int? DealID { get; set; }
        [JsonProperty("discount")]
        public int? Discount { get; set; }
    }

    public class OrderResponse : OrderRequest {
        public OrderResponse(OrderResponse source) : this() => ClassCopier.Copy(source, this);
        public OrderResponse() : base() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
