using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/notes
namespace ZendeskSell.Notes {
    public class NoteActions : INoteActions {
        private RestClient _client;

        public NoteActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<NoteResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("notes", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<NoteResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<NoteResponse>> GetOneAsync(long id) {
            var request = new RestRequest($"notes/{id}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<NoteResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<NoteResponse>> CreateAsync(NoteRequest note) {
            Require.Argument("ResourceType", note.ResourceType);
            Require.Argument("ResourceID", note.ResourceID == 0 ? (object)null : note.ResourceID);
            Require.Argument("Content", note.Content);

            var request = new RestRequest("notes", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<NoteRequest>(note));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<NoteResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<NoteResponse>> UpdateAsync(long id, NoteRequest note) {
            Require.Argument("ResourceType", note.ResourceType);
            Require.Argument("ResourceID", note.ResourceID == 0 ? (object)null : note.ResourceID);
            Require.Argument("Content", note.Content);

            var request = new RestRequest($"notes/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<NoteRequest>(note));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<NoteResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(long id) {
            var request = new RestRequest($"notes/{id}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
