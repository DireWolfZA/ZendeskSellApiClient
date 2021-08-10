using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/leads
namespace ZendeskSell.Leads {
    public class LeadActions : ILeadActions {
        private RestClient _client;

        public LeadActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadResponse>> GetAsync(int pageNumber, int numPerPage,
                string email = null, string phone = null, string mobile = null, int? ownerID = null) {
            var request = new RestRequest("leads", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (email != null)
                request.AddParameter("email", email);
            if (phone != null)
                request.AddParameter("phone", phone);
            if (mobile != null)
                request.AddParameter("mobile", mobile);
            if (ownerID != null)
                request.AddParameter("owner_id", ownerID);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<LeadResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"leads/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> CreateAsync(LeadRequest lead) {
            var request = new RestRequest("leads", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadRequest>(lead));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LeadResponse>> UpdateAsync(int id, LeadRequest lead) {
            var request = new RestRequest($"leads/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadRequest>(lead));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<LeadResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"leads/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
