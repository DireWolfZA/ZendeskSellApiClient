using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZendeskSell.CustomFields {
    public class CustomFieldResponse {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("for_organisation")]
        public bool ForOrganisation { get; set; }
        [JsonProperty("for_contact")]
        public bool ForContact { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("choices")]
        public IEnumerable<Choice> Choices { get; set; }
    }

    public class Choice {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public static class ZendeskTypeToDotNetType {
        public static Dictionary<string, Type> typeMap = new Dictionary<string, Type>() {
            { "address", typeof(Models.Address) },
            { "bool", typeof(bool) },
            { "date", typeof(string) },
            { "datetime", typeof(string) },
            { "email", typeof(string) },
            { "list", typeof(string) },
            { "multi_select_list", typeof(IEnumerable<string>) },
            { "number", typeof(string) },
            { "phone", typeof(string) },
            { "string", typeof(string) },
            { "text", typeof(string) },
            { "url", typeof(string) }
        };

        public static Type GetType(string type) => typeMap[type];
    }
}
