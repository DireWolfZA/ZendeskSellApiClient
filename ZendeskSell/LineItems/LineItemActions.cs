using RestSharp;

namespace ZendeskSell.LineItems {
    public class LineItemActions : ILineItemActions {
        private RestClient client;

        public LineItemActions(RestClient client) {
            this.client = client;
        }
    }
}