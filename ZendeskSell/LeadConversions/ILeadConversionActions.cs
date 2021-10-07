using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.LeadConversions {
    public interface ILeadConversionActions {
        Task<ZendeskSellCollectionResponse<LeadConversionResponse>> GetAsync(int pageNumber, int numPerPage, int? leadID = null, int? individualID = null, int? organizationID = null, int? dealID = null);
        Task<ZendeskSellObjectResponse<LeadConversionResponse>> CreateAsync(LeadConversionRequest leadConversion);
    }
}
