using Newtonsoft.Json;

namespace ZendeskSell.SequenceEnrollments {
    public class SequenceEnrollmentCreateRequest {
        [JsonProperty("sequence_id")]
        public int SequenceID { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public int ResourceID { get; set; }
        [JsonProperty("actor_id")]
        public int? ActorID { get; set; }
    }

    public class SequenceEnrollmentUpdateRequest {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
