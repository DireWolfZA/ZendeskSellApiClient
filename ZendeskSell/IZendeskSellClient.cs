using ZendeskSell.Contacts;
using ZendeskSell.Deals;
using ZendeskSell.DealSources;
using ZendeskSell.Leads;
using ZendeskSell.LineItems;
using ZendeskSell.Orders;
using ZendeskSell.Products;
using ZendeskSell.Tasks;

namespace ZendeskSell {
    public interface IZendeskSellClient {
        IContactActions Contacts { get; }

        IDealActions Deals { get; }
        IDealSourceActions DealSources { get; }

        ILeadActions Leads { get; }

        ILineItemActions LineItems { get; }

        IOrderActions Orders { get; }

        IProductActions Products { get; }

        ITaskActions Tasks { get; }
    }
}