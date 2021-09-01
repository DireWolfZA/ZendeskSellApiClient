using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZendeskSell.Users {
    public class UserResponse {
        public UserResponse(UserResponse source) : this() => ClassCopier.Copy(source, this);
        public UserResponse() { }

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("invited")]
        public bool? Invited { get; set; }
        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }
        [JsonProperty("role")]
        public UserRole Role { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }
        [JsonProperty("roles")]
        public IEnumerable<IDAndName> Roles { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("reports_to")]
        public int? ReportsTo { get; set; }
        [JsonProperty("team_name")]
        public string TeamName { get; set; }
        [JsonProperty("group")]
        public IDAndName Group { get; set; }
        [JsonProperty("detached")]
        public bool Detached { get; set; }
        [JsonProperty("identity_type")]
        public string IdentityType { get; set; }
        [JsonProperty("system_tags")]
        public IEnumerable<string> SystemTags { get; set; }
        [JsonProperty("zendesk_user_id")]
        public long ZendeskUserID { get; set; }
        [JsonProperty("sell_login_disabled")]
        public bool SellLoginDisabled { get; set; }
    }

    public enum UserRole {
        User,
        Admin
    }

    public class IDAndName {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
