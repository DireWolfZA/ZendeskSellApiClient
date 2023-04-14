using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Collaborations {
    public class CollaborationRequest {
        public CollaborationRequest(CollaborationRequest source) : this() => ClassCopier.Copy(source, this);
        public CollaborationRequest() { }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public long ResourceID { get; set; }
        [JsonProperty("collaborator_id")]
        public int CollaboratorID { get; set; }
    }
}
