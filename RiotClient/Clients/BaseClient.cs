using CoffeeCat.RiotClient.Endpoints;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Clients
{
    public class BaseClient
    {
        private WebClient webClient;

        internal EndpointFactory EndpointFactory;

        public string Region { get; private set; }

        public string ApiKey { get; private set; }

        public BaseClient(string region, string apiKey)
        {
            Validation.ValidateNotNullOrWhitespace(region, nameof(region));
            Validation.ValidateNotNullOrWhitespace(apiKey, nameof(apiKey));

            this.Region = region;
            this.ApiKey = apiKey;
            this.EndpointFactory = new EndpointFactory(apiKey, region);
            this.webClient = new WebClient();
        }

        protected async Task<T> DownloadRiotData<T>(Uri uri) where T : class
        {
            Validation.ValidateNotNull(uri, nameof(uri));

            string json = await this.webClient.DownloadStringTaskAsync(uri);
            return JsonUtils.Deserialize<T>(json);
        }
    }
}
