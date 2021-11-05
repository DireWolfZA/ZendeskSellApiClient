using System;
using Newtonsoft.Json;

namespace ZendeskSell.DealUnqualifiedReasons {
    public class DealUnqualifiedReasonRequest {
        public DealUnqualifiedReasonRequest(DealUnqualifiedReasonRequest reason) : this() => ClassCopier.Copy(reason, this);
        public DealUnqualifiedReasonRequest() { }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DealUnqualifiedReasonResponse : DealUnqualifiedReasonRequest {
        public DealUnqualifiedReasonResponse(DealUnqualifiedReasonResponse reason) : this() => ClassCopier.Copy(reason, this);
        public DealUnqualifiedReasonResponse() : base() { }

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
