using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.DealLossReasons {
    public class DealLossReasonRequest {
        public DealLossReasonRequest(DealLossReasonRequest reason) : this() => ClassCopier.Copy(reason, this);
        public DealLossReasonRequest() { }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DealLossReasonResponse : DealLossReasonRequest {
        public DealLossReasonResponse(DealLossReasonResponse reason) : this() => ClassCopier.Copy(reason, this);
        public DealLossReasonResponse() : base() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
