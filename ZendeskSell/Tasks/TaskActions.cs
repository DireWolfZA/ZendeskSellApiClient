using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/tasks
namespace ZendeskSell.Tasks {
    public class TaskActions : ITaskActions {
        private RestClient _client;

        public TaskActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<TaskResponse>> GetAsync(int pageNumber, int numPerPage, long? resourceID = null, string resourceType = null) {
            var request = new RestRequest("tasks", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (resourceID != null)
                request.AddParameter("resource_id", resourceID);
            if (resourceType != null)
                request.AddParameter("resource_type", resourceType);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<TaskResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> GetOneAsync(long id) {
            var request = new RestRequest($"tasks/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> CreateAsync(TaskRequest task) {
            Require.Argument("OwnerID", task.OwnerID == 0 ? (object)null : task.OwnerID);
            Require.Argument("Content", task.Content);
            Require.Argument("ResourceType", task.ResourceType);
            Require.Argument("ResourceID", task.ResourceID == 0 ? (object)null : task.ResourceID);

            var request = new RestRequest("tasks", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<TaskRequest>(task));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> UpdateAsync(long id, TaskRequest task) {
            Require.Argument("OwnerID", task.OwnerID == 0 ? (object)null : task.OwnerID);
            Require.Argument("Content", task.Content);
            Require.Argument("ResourceType", task.ResourceType);
            Require.Argument("ResourceID", task.ResourceID == 0 ? (object)null : task.ResourceID);

            var request = new RestRequest($"tasks/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<TaskRequest>(task));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(long id) {
            var request = new RestRequest($"tasks/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
