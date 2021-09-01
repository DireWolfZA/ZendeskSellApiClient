using System;
using Newtonsoft.Json;

namespace ZendeskSell.Contacts {
    public class ContactResponse : ContactRequest {
        public ContactResponse(ContactResponse source) : this() => ClassCopier.Copy(source, this);
        public ContactResponse() : base() { }
        public string GetLink() => $"https://app.futuresimple.com/crm/contacts/{ID}";

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
