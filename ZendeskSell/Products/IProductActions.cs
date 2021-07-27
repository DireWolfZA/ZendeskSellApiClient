using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Products {
    public interface IProductActions {
        Task<ZendeskSellCollectionResponse<ProductResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<ProductResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<ProductResponse>> CreateAsync(ProductRequest product);
        Task<ZendeskSellObjectResponse<ProductResponse>> UpdateAsync(int id, ProductRequest product);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
