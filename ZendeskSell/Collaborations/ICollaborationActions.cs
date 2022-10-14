using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Collaborations {
    public interface ICollaborationActions {
        Task<ZendeskSellCollectionResponse<CollaborationResponse>> GetAsync(int pageNumber, int numPerPage, int? creatorID = null, int? resourceID = null, string resourceType = null);
        Task<ZendeskSellObjectResponse<CollaborationResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<CollaborationResponse>> CreateAsync(CollaborationRequest collaboration);
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
