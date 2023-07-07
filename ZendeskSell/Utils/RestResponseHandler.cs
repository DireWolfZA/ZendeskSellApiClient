using RestSharp;
using RestSharp.Serialization.Json;
using ZendeskSell.Models;

namespace ZendeskSell.Utils {
    static class RestResponseHandler {
        public const string ExceptionDataKey = "Content";

        public static T Handle<T>(IRestResponse<T> response) {
            if (response.ErrorException != null) {
                var ex = response.ErrorException;
                ex.Data[ExceptionDataKey] = response.Content;
                throw ex;
            }

            if (response.Content.StartsWith("{\"status\":")) {
                var deserializer = new JsonDeserializer();
                var statusWithError = deserializer.Deserialize<ZendeskResponseStatusWithError>(response);
                if (statusWithError != null && statusWithError.Status != null) {
                    var ex = new System.Net.WebException($"Zendesk Sell Error: Status:{statusWithError.Status} Error:{statusWithError.Error}");
                    ex.Data[ExceptionDataKey] = response.Content;
                    throw ex;
                }
            }
            return response.Data;
        }
    }
}
