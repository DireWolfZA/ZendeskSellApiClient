using RestSharp;
using ZendeskSell.Contacts;
using ZendeskSell.Deals;
using ZendeskSell.DealSources;
using ZendeskSell.Leads;
using ZendeskSell.LeadSources;
using ZendeskSell.LineItems;
using ZendeskSell.Orders;
using ZendeskSell.Products;
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

        public IContactActions Contacts => new ContactActions(_client);

        public IDealActions Deals => new DealActions(_client);
        public IDealSourceActions DealSources => new DealSourceActions(_client);

        public ILeadActions Leads => new LeadActions(_client);
        public ILeadSourceActions LeadSources => new LeadSourceActions(_client);

        public ILineItemActions LineItems => new LineItemActions(_client);

        public IOrderActions Orders => new OrderActions(_client);

        public IProductActions Products => new ProductActions(_client);

        public IStageActions Stages => new StageActions(_client);

        public ITaskActions Tasks => new TaskActions(_client);

        public IUserActions Users => new UserActions(_client);
    }
}
