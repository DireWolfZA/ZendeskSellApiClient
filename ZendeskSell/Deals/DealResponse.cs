using System;
using Newtonsoft.Json;

namespace ZendeskSell.Deals {
    public class DealResponse : DealRequest {
        public DealResponse(DealResponse source) : this() => ClassCopier.Copy(source, this);
        public DealResponse() : base() { }
        public string GetLink() => $"https://app.futuresimple.com/sales/deals/{ID}";

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("last_stage_change_by_id")]
        public int? LastStageChangeByID { get; set; }
        [JsonProperty("last_activity_at")]
        public DateTimeOffset LastActivityAt { get; set; }
        [JsonProperty("dropbox_email")]
        public string DropboxEmail { get; set; }
        [JsonProperty("organization_id")]
        public int? OrganizationID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
