using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Products {
    public class ProductResponse : ProductRequest {
        public ProductResponse(ProductResponse source) : this() => ClassCopier.Copy(source, this);
        public ProductResponse() : base() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("max_markup")]
        public string MaxMarkup { get; set; }
    }
}
