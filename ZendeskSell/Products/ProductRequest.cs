using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ZendeskSell.Products {
    public class ProductRequest {
        public ProductRequest(ProductRequest source) : this() => ClassCopier.Copy(source, this);
        public ProductRequest() {
            Prices = Enumerable.Empty<ProductPrice>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sku")]
        public string SKU { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("cost")]
        public string Cost { get; set; }
        [JsonProperty("cost_currency")]
        public string CostCurrency { get; set; }
        [JsonProperty("max_discount")]
        public int? MaxDiscount { get; set; }
        [JsonProperty("prices")]
        public IEnumerable<ProductPrice> Prices { get; set; }
    }
}
