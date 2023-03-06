using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Notes {
    public interface INoteActions {
        Task<ZendeskSellCollectionResponse<NoteResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<NoteResponse>> GetOneAsync(long id);
        Task<ZendeskSellObjectResponse<NoteResponse>> CreateAsync(NoteRequest note);
        Task<ZendeskSellObjectResponse<NoteResponse>> UpdateAsync(long id, NoteRequest note);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(long id);
    }
}
