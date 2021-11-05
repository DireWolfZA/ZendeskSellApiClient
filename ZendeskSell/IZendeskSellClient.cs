using ZendeskSell.Contacts;
using ZendeskSell.CustomFields;
using ZendeskSell.DealLossReasons;
using ZendeskSell.Deals;
using ZendeskSell.DealSources;
using ZendeskSell.DealUnqualifiedReasons;
using ZendeskSell.LeadConversions;
using ZendeskSell.Leads;
using ZendeskSell.LeadSources;
using ZendeskSell.LineItems;
using ZendeskSell.Orders;
using ZendeskSell.Products;
using ZendeskSell.SequenceEnrollments;
using ZendeskSell.Stages;
using ZendeskSell.Tasks;
using ZendeskSell.Users;

namespace ZendeskSell {
    public interface IZendeskSellClient {
        IContactActions Contacts { get; }

        ICustomFieldActions CustomFields { get; }

        IDealActions Deals { get; }
        IDealSourceActions DealSources { get; }
        IDealLossReasonActions DealLossReasons { get; }
        IDealUnqualifiedReasonActions DealUnqualifiedReasons { get; }

        ILeadActions Leads { get; }
        ILeadSourceActions LeadSources { get; }
        ILeadConversionActions LeadConversions { get; }

        ILineItemActions LineItems { get; }

        IOrderActions Orders { get; }

        IProductActions Products { get; }

        ISequenceEnrollmentActions SequenceEnrollments { get; }

        IStageActions Stages { get; }

        ITaskActions Tasks { get; }

        IUserActions Users { get; }
    }
}
