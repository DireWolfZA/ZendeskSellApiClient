using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/lead_conversions
namespace ZendeskSell.LeadConversions {
    public class LeadConversionActions : ILeadConversionActions {
        private RestClient _client;

        public LeadConversionActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadConversionResponse>> GetAsync(int pageNumber, int numPerPage, long? leadID = null, long? individualID = null, long? organizationID = null, long? dealID = null) {
            var request = new RestRequest("lead_conversions", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (leadID != null)
                request.AddParameter("lead_id", leadID);
            if (individualID != null)
                request.AddParameter("individual_id", individualID);
            if (organizationID != null)
                request.AddParameter("organization_id", organizationID);
            if (dealID != null)
                request.AddParameter("deal_id", dealID);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<LeadConversionResponse>>(request, Method.GET));
        }
        public async Task<ZendeskSellObjectResponse<LeadConversionResponse>> CreateAsync(LeadConversionRequest leadConversion) {
            Require.Argument("LeadID", leadConversion.LeadID == 0 ? null : (object)leadConversion.LeadID);

            var request = new RestRequest("lead_conversions", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadConversionRequest>(leadConversion));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadConversionResponse>>(request, Method.POST));
        }
    }
}
