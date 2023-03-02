using RestSharp;
using ZendeskSell.AssociatedContacts;
using ZendeskSell.Collaborations;
using ZendeskSell.Contacts;
using ZendeskSell.CustomFields;
using ZendeskSell.DealLossReasons;
using ZendeskSell.Deals;
using ZendeskSell.DealSources;
using ZendeskSell.DealUnqualifiedReasons;
using ZendeskSell.Documents;
using ZendeskSell.LeadConversions;
using ZendeskSell.Leads;
using ZendeskSell.LeadSources;
using ZendeskSell.LeadUnqualifiedReasons;
using ZendeskSell.LineItems;
using ZendeskSell.Notes;
using ZendeskSell.Orders;
using ZendeskSell.Products;
using ZendeskSell.SequenceEnrollments;
using ZendeskSell.Stages;
using ZendeskSell.Tasks;
using ZendeskSell.Users;

namespace ZendeskSell {
    public class ZendeskSellClient : IZendeskSellClient {

        private readonly string _baseUrl = "https://api.getbase.com/v2";
        private readonly RestClient _client;

        /// <summary>
        /// Object Constructor for Zendesk Item!
        /// </summary>
        public ZendeskSellClient(string accessToken) {
            _client = new RestClient(_baseUrl);
            _client
                .AddDefaultHeader("Authorization", $"Bearer {accessToken}")
                .AddDefaultHeader("Accept", "application/json")
                .AddDefaultHeader("Content-Type", "application/json");
        }

        public ICollaborationActions Collaborations => new CollaborationActions(_client);

        public IContactActions Contacts => new ContactActions(_client);

        public ICustomFieldActions CustomFields => new CustomFieldActions(_client);

        public IDealActions Deals => new DealActions(_client);
        public IDealSourceActions DealSources => new DealSourceActions(_client);
        public IDealLossReasonActions DealLossReasons => new DealLossReasonActions(_client);
        public IDealUnqualifiedReasonActions DealUnqualifiedReasons => new DealUnqualifiedReasonActions(_client);
        public IAssociatedContactActions AssociatedContacts => new AssociatedContactActions(_client);

        public IDocumentActions Documents => new DocumentActions(_client);

        public ILeadActions Leads => new LeadActions(_client);
        public ILeadSourceActions LeadSources => new LeadSourceActions(_client);
        public ILeadUnqualifiedReasonActions LeadUnqualifiedReasons => new LeadUnqualifiedReasonActions(_client);
        public ILeadConversionActions LeadConversions => new LeadConversionActions(_client);

        public ILineItemActions LineItems => new LineItemActions(_client);

        public INoteActions Notes => new NoteActions(_client);

        public IOrderActions Orders => new OrderActions(_client);

        public IProductActions Products => new ProductActions(_client);

        public ISequenceEnrollmentActions SequenceEnrollments => new SequenceEnrollmentActions(_client);

        public IStageActions Stages => new StageActions(_client);

        public ITaskActions Tasks => new TaskActions(_client);

        public IUserActions Users => new UserActions(_client);
    }
}
