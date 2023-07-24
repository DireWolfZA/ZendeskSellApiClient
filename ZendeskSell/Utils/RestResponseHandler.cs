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

            if (response.Content.StartsWith("<html>")) { // usually <html><head><title>504 Gateway Time-out</title></head><body><center><h1>504 Gateway Time-out</h1></center><hr><center>nginx</center></body></html>
                const string titleTag = "<title>";
                const string h1Tag = "<h1>";
                int titleStartPosition = response.Content.IndexOf(titleTag) + titleTag.Length;
                int h1StartPosition = response.Content.IndexOf(h1Tag) + h1Tag.Length;

                string title = response.Content.Substring(titleStartPosition, response.Content.IndexOf("</", titleStartPosition) - titleStartPosition);
                string h1 = response.Content.Substring(h1StartPosition, response.Content.IndexOf("</", h1StartPosition) - h1StartPosition);

                var ex = new System.Net.WebException($"Zendesk Sell Error:{title} Description:{h1}");
                ex.Data[ExceptionDataKey] = response.Content;
                throw ex;
            }

            if (response.Content.StartsWith(@"{""status"":")) { // usually {"status":500,"error":"Internal Server Error"}
                var deserializer = new JsonDeserializer();
                var statusWithError = deserializer.Deserialize<ZendeskResponseStatusWithError>(response);
                if (statusWithError != null && statusWithError.Status.HasValue) {
                    var ex = new System.Net.WebException($"Zendesk Sell Error: Status:{statusWithError.Status} Error:{statusWithError.Error}");
                    ex.Data[ExceptionDataKey] = response.Content;
                    throw ex;
                }
            }
            return response.Data;
        }
    }
}
