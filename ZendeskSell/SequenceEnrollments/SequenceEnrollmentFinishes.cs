using Newtonsoft.Json;
using ZendeskSell.Models;

namespace ZendeskSell.SequenceEnrollments {
    public class SequenceEnrollmentFinishRequest {
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public long ResourceID { get; set; }
        [JsonProperty("sequence_ids")]
        public int[] SequenceIDs { get; set; }
    }

    public class SequenceEnrollmentFinishResponse {
        [JsonProperty("enrollment_action")]
        public string EnrollmentAction { get; set; }
        [JsonProperty("updated_enrollments")]
        public ZendeskSellCollectionResponse<SequenceEnrollmentResponse> UpdatedEnrollments { get; set; }
    }
}
