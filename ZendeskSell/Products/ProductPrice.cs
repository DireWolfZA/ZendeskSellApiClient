using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Products {
    public class ProductPrice {
        public ProductPrice(ProductPrice source) : this() => ClassCopier.Copy(source, this);
        public ProductPrice() { }

        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
