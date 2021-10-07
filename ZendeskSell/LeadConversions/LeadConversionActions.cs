using System.Threading.Tasks;
using RestSharp;
using RestSharp.Validation;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/lead_conversions
namespace ZendeskSell.LeadConversions {
    public class LeadConversionActions : ILeadConversionActions {
        private RestClient _client;

        public LeadConversionActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadConversionResponse>> GetAsync(int pageNumber, int numPerPage, int? leadID = null, int? individualID = null, int? organizationID = null, int? dealID = null) {
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
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<LeadConversionResponse>>(request, Method.GET)).Data;
        }
        public async Task<ZendeskSellObjectResponse<LeadConversionResponse>> CreateAsync(LeadConversionRequest leadConversion) {
            Require.Argument("LeadID", leadConversion.LeadID == 0 ? null : (object)leadConversion.LeadID);

            var request = new RestRequest("lead_conversions", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadConversionRequest>(leadConversion));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<LeadConversionResponse>>(request, Method.POST)).Data;
        }
    }
}
