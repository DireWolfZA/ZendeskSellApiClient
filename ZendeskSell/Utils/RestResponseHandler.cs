using RestSharp;

namespace ZendeskSell.Utils {
    static class RestResponseHandler {
        public static T Handle<T>(IRestResponse<T> response) {
            if (response.ErrorException != null)
                throw response.ErrorException;
            return response.Data;
        }
    }
}
