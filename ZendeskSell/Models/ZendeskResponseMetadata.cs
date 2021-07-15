using Newtonsoft.Json;

namespace ZendeskSell.Models {
    public class ZendeskResponseMetadata {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("http_status")]
        public string HTTPStatus { get; set; }
        [JsonProperty("logref")]
        public string Logref { get; set; }
        [JsonProperty("links")]
        public ZendeskResponseLinkMetadata Links { get; set; }
    }

    public class ZendeskResponseLinkMetadata {
        [JsonProperty("more_info")]
        public string MoreInfo { get; set; }
    }
}
