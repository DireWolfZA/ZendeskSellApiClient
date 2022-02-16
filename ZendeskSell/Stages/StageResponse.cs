using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Stages {
    public class StageResponse {
        public StageResponse(StageResponse source) : this() => ClassCopier.Copy(source, this);
        public StageResponse() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("likelihood")]
        public int? Likelihood { get; set; }
        [JsonProperty("pipeline_id")]
        public int PipelineID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
