using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/leads
namespace ZendeskSell.Leads {
    public class LeadActions : ILeadActions {
        private RestClient _client;

        public LeadActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null,
                string email = null, string phone = null, string mobile = null, string status = null, int? ownerID = null) {
            var request = new RestRequest("leads", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (customFields != null)
                foreach (var field in customFields)
                    request.AddParameter($"custom_fields[{field.Key}]", field.Value);
            if (email != null)
                request.AddParameter("email", email);
            if (phone != null)
                request.AddParameter("phone", phone);
            if (mobile != null)
                request.AddParameter("mobile", mobile);
            if (status != null)
                request.AddParameter("status", status);
            if (ownerID != null)
                request.AddParameter("owner_id", ownerID);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<LeadResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"leads/{id}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> CreateAsync(LeadRequest lead) {
            var request = new RestRequest("leads", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadRequest>(lead));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> UpdateAsync(int id, LeadRequest lead) {
            var request = new RestRequest($"leads/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadRequest>(lead));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"leads/{id}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
