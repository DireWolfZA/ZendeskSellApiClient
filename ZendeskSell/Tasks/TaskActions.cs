using System.Threading.Tasks;
using RestSharp;
using RestSharp.Validation;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/tasks
namespace ZendeskSell.Tasks {
    public class TaskActions : ITaskActions {
        private RestClient _client;

        public TaskActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<TaskResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("tasks", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<TaskResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"tasks/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> CreateAsync(TaskRequest task) {
            Require.Argument("OwnerID", task.OwnerID == 0 ? (object)null : task.OwnerID);
            Require.Argument("Content", task.Content);
            Require.Argument("ResourceType", task.ResourceType);
            Require.Argument("ResourceID", task.ResourceID == 0 ? (object)null : task.ResourceID);

            var request = new RestRequest("tasks", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<TaskRequest>(task));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<TaskResponse>> UpdateAsync(int id, TaskRequest task) {
            Require.Argument("OwnerID", task.OwnerID == 0 ? (object)null : task.OwnerID);
            Require.Argument("Content", task.Content);
            Require.Argument("ResourceType", task.ResourceType);
            Require.Argument("ResourceID", task.ResourceID == 0 ? (object)null : task.ResourceID);

            var request = new RestRequest($"tasks/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<TaskRequest>(task));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<TaskResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"tasks/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}