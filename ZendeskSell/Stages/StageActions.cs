using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

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
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<StageResponse>>(request, Method.GET));
        }
    }
}
