using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Collaborations {
    public class CollaborationResponse : CollaborationRequest {
        public CollaborationResponse(CollaborationResponse source) : this() => ClassCopier.Copy(source, this);
        public CollaborationResponse() : base() { }

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
