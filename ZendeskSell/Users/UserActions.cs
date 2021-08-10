using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/users
namespace ZendeskSell.Users {
    public class UserActions : IUserActions {
        private RestClient _client;

        public UserActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<UserResponse>> GetAsync(int pageNumber, int numPerPage, string name = null) {
            var request = new RestRequest("users", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (name != null)
                request.AddParameter("name", name);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<UserResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<UserResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"users/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<UserResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<UserResponse>> GetCurrentAsync() {
            var request = new RestRequest($"users/self", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<UserResponse>>(request, Method.GET)).Data;
        }
    }
}
