using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Documents {
    public interface IDocumentActions {
        Task<ZendeskSellCollectionResponse<DocumentResponse>> GetAsync(int pageNumber, int numPerPage, string resourceType, long resourceID, string sortBy = null, string ids = null, string name = null);
        Task<ZendeskSellObjectResponse<DocumentResponse>> GetOneAsync(int id);
    }
}
