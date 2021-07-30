using ZendeskSell.Contacts;
using ZendeskSell.Deals;
using ZendeskSell.DealSources;
using ZendeskSell.Leads;
using ZendeskSell.LeadSources;
using ZendeskSell.LineItems;
using ZendeskSell.Orders;
using ZendeskSell.Products;
using ZendeskSell.Tasks;
using ZendeskSell.Users;

namespace ZendeskSell {
    public interface IZendeskSellClient {
        IContactActions Contacts { get; }

        IDealActions Deals { get; }
        IDealSourceActions DealSources { get; }

        ILeadActions Leads { get; }
        ILeadSourceActions LeadSources { get; }

        ILineItemActions LineItems { get; }

        IOrderActions Orders { get; }

        IProductActions Products { get; }

        ITaskActions Tasks { get; }

        IUserActions Users { get; }
    }
}