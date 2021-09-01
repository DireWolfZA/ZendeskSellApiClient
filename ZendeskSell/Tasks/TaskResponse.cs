using System;
using Newtonsoft.Json;

namespace ZendeskSell.Tasks {
    public class TaskResponse : TaskRequest {
        public TaskResponse(TaskResponse source) : this() => ClassCopier.Copy(source, this);
        public TaskResponse() : base() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("completed_at")]
        public DateTimeOffset? CompletedAt { get; set; }
        [JsonProperty("overdue")]
        public bool Overdue { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
