using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZendeskSell.Models {
    public class ZendeskSellDeleteResponse {
        [JsonProperty("meta")]
        public ZendeskResponseMetadata Meta { get; set; }

        [JsonProperty("errors")]
        public IEnumerable<ZendeskResponseError> Errors { get; set; }
    }

    public class ZendeskSellObjectResponse<T> : ZendeskSellDeleteResponse where T : class {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
