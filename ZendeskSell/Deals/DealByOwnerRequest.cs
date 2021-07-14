using Newtonsoft.Json;

namespace ZendeskSell.Deals {
    public class DealByOwnerRequest : DealRequest {
        public DealByOwnerRequest() : base() {
        }

        [JsonProperty("owner_id")]
        public int OwnerID { get; set; }
    }
}