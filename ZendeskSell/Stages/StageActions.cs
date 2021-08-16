using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/stages
namespace ZendeskSell.Stages {
    public class StageActions : IStageActions {
        private RestClient _client;

        public StageActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<StageResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("stages", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<StageResponse>>(request, Method.GET)).Data;
        }
    }
}
