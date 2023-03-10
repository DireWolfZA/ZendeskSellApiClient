using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/lead_unqualified_reasons
namespace ZendeskSell.LeadUnqualifiedReasons {
    public class LeadUnqualifiedReasonActions : ILeadUnqualifiedReasonActions {
        private RestClient _client;

        public LeadUnqualifiedReasonActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadUnqualifiedReasonResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("lead_unqualified_reasons", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<LeadUnqualifiedReasonResponse>>(request, Method.GET));
        }
    }
}
