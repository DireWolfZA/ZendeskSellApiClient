using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Stages {
    public interface IStageActions {
        Task<ZendeskSellCollectionResponse<StageResponse>> GetAsync(int pageNumber, int numPerPage);
    }
}
