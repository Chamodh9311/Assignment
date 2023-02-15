namespace Assignment.Model
{
    public class AssignmentModel
    {
        public class InverseText
        {
            public string? Text { get; set; }
        }

        public class Asset
        {
            public string AssetName { get; set; }
            public string AssetSymbol { get; set; }
            public object MarketCap { get; set; }
        }

        public class Data
        {
            public List<Asset> Assets { get; set; }
        }

        public class Root
        {
            public Data Data { get; set; }
        }


        public class PriceData
        {
            public List<Market> Markets { get; set; }
        }

        public class Market
        {
            public string MarketSymbol { get; set; }
            public Ticker Ticker { get; set; }
        }

        public class RootPrice
        {
            public PriceData Data { get; set; }
        }

        public class Ticker
        {
            public string LastPrice { get; set; }
        }

    }
}
