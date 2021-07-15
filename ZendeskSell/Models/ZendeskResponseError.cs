using Newtonsoft.Json;

namespace ZendeskSell.Models {
    public class ZendeskResponseError {
        [JsonProperty("error")]
        public ZendeskResponseErrorData Error { get; set; }
        [JsonProperty("meta")]
        public ZendeskResponseMetadata Meta { get; set; }
    }

    public class ZendeskResponseErrorData {
        [JsonProperty("resource")]
        public string Resource { get; set; }
        [JsonProperty("field")]
        public string Field { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
    }

}
