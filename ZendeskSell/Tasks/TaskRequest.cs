using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Tasks {
    public class TaskRequest {
        public TaskRequest(TaskRequest source) : this() => ClassCopier.Copy(source, this);
        public TaskRequest() { }

        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("due_date")]
        public DateTimeOffset? DueDate { get; set; }
        [JsonProperty("owner_id")]
        public int OwnerID { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public int ResourceID { get; set; }
        [JsonProperty("completed")]
        public bool Completed { get; set; }
        [JsonProperty("remind_at")]
        public DateTimeOffset? RemindAt { get; set; }
    }
}
