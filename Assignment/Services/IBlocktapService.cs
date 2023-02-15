using static Assignment.Model.AssignmentModel;

namespace Assignment.Service
{
    public interface IBlockTapService
    {
        public Task<Root> PageAssets();
        public Task<List<Market>> Price(string Crypto = "BTC");
    }
}
