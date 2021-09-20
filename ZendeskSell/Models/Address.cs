using Newtonsoft.Json;

//https://developers.getbase.com/docs/rest/reference/address
namespace ZendeskSell.Models {
    public class Address {
        public Address(Address source) : this() => ClassCopier.Copy(source, this);
        public Address() { }

        [JsonProperty("line1")]
        public string Line1 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
