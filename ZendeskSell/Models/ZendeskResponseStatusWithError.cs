using Newtonsoft.Json;

namespace ZendeskSell.Models {
    public class ZendeskResponseStatusWithError {
        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
