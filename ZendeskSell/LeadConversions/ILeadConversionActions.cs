using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.LeadConversions {
    public interface ILeadConversionActions {
        Task<ZendeskSellCollectionResponse<LeadConversionResponse>> GetAsync(int pageNumber, int numPerPage, long? leadID = null, long? individualID = null, long? organizationID = null, long? dealID = null);
        Task<ZendeskSellObjectResponse<LeadConversionResponse>> CreateAsync(LeadConversionRequest leadConversion);
    }
}
