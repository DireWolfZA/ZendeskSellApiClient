using System;
using Newtonsoft.Json;
using ZendeskSell.Utils;

namespace ZendeskSell.AssociatedContacts {
    public class AssociatedContactRequest {
        public AssociatedContactRequest(AssociatedContactRequest source) : this() => ClassCopier.Copy(source, this);
        public AssociatedContactRequest() { }

        [JsonProperty("contact_id")]
        public int ContactID { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class AssociatedContactResponse:AssociatedContactRequest {
        public AssociatedContactResponse(AssociatedContactResponse source) : this() => ClassCopier.Copy(source, this);
        public AssociatedContactResponse() : base() { }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
