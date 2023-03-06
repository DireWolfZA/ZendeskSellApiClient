using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.Deals {
    public class DealRequest {
        public DealRequest(DealRequest source) : this() => ClassCopier.Copy(source, this);
        public DealRequest() {
            Tags = new string[] { };
            CustomFields = new Dictionary<string, object>();
        }

        [JsonProperty("value")]
        public string Value { get; set; }
        public decimal GetValue() => decimal.Parse(Value, System.Globalization.NumberFormatInfo.InvariantInfo);

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("contact_id")]
        public long ContactID { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("owner_id")]
        public int? OwnerID { get; set; }
        [JsonProperty("hot")]
        public bool Hot { get; set; }
        [JsonProperty("stage_id")]
        public int? StageID { get; set; }
        [JsonProperty("last_stage_change_at")]
        public DateTimeOffset? LastStageChangeAt { get; set; }
        [JsonProperty("added_at")]
        public DateTimeOffset? AddedAt { get; set; }
        [JsonProperty("source_id")]
        public int? SourceID { get; set; }
        [JsonProperty("loss_reason_id")]
        public int? LossReasonID { get; set; }
        [JsonProperty("unqualified_reason_id")]
        public int? UnqualifiedReasonID { get; set; }
        [JsonProperty("estimated_close_date")]
        public DateTimeOffset? EstimatedCloseDate { get; set; }
        [JsonProperty("customized_win_likelihood")]
        public int? CustomizedWinLikelihood { get; set; }
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
        [JsonProperty("custom_fields")]
        public Dictionary<string, object> CustomFields { get; set; }
    }
}
