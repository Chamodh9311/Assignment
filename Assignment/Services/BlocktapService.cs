using Newtonsoft.Json;
using RestSharp;
using static Assignment.Model.AssignmentModel;

namespace Assignment.Service
{
    public class BlockTapService : IBlocktapService
    {
        private readonly IConfiguration _configuration;

        public BlockTapService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Root> PageAssets()
        {
            var query = "{\"query\":\"query PageAssets {\\r\\n  assets(sort: [{marketCapRank: ASC}]) {\\r\\n    assetName\\r\\n    assetSymbol\\r\\n    marketCap\\r\\n  }\\r\\n}\",\"variables\":{}}";
            var Result = GraphQL(query);

            return JsonConvert.DeserializeObject<Root>(Result.Content);

        }

        public async Task<List<Market>> Price(string Crypto = "BTC")
        {
            var query = "{\"query\":\"query price {\\r\\n  markets(filter: {baseSymbol: {_eq: \\\"" + Crypto + "\\\"}, quoteSymbol: {_eq: \\\"" + _configuration["BlockTap:DefaultCurrency"] + "\\\"}, exchangeSymbol: {_eq: \\\"" 
                + _configuration["BlockTap:Exchange"] + "\\\"}}) {\\r\\n    marketSymbol\\r\\n    ticker {\\r\\n      lastPrice\\r\\n    }\\r\\n  }\\r\\n}\",\"variables\":{}}";
            var Result = GraphQL(query);

            var temp = JsonConvert.DeserializeObject<RootPrice>(Result.Content);
            return temp.Data.Markets;

        }

        private RestResponse GraphQL(string query)
        {
            RestClient client = new RestClient(_configuration["BlockTap:BaseUrl"]);
            RestRequest? request = new RestRequest("/graphql", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", query, ParameterType.RequestBody);
            return client.Execute(request);
        }
    }
}
