using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Users {
    public interface IUserActions {
        Task<ZendeskSellCollectionResponse<UserResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<UserResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<UserResponse>> GetCurrentAsync();
    }
}
