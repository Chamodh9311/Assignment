using System.Security.Cryptography;
using System.Text;
using static Assignment.Model.AssignmentModel;

namespace Assignment.Service
{
    public class AssignmentService: IAssignmentService
    {
        private readonly IBlockTapService _iBlockTapService;

        public AssignmentService(IBlockTapService iBlockTapService)
        {
            _iBlockTapService = iBlockTapService;
        }
        //Use for Reverse or Inverse Text
        public async Task<string> StringReverser(InverseText Request)
        {
            if(Request.Text != null) { 
                char[] stringArray = Request.Text.ToCharArray();
                Array.Reverse(stringArray);
                string ReverseString = new string(stringArray);
                return ReverseString;
            }
            else
            {
                return "Please Enter any Value";
            }
        }

        //Calculate SHA Value
        public string GetMD5HashFromFile(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public async Task<List<Market>> PageAssets()
        {
            List<Market> returnData = new List<Market>();
            var AllData = await _iBlockTapService.PageAssets();
            for (int i = 0; i<=20;i++)
            {
                var Currency = AllData.Data.Assets[i];
                var market = await _iBlockTapService.Price(Currency.AssetSymbol);
                if(market.Count() != 0) { 
                    returnData.Add(market[0]);
                }
            }
            return returnData;
        }


        public List<int> FunctionA()
        {
            List<int> ReturnData = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var Data = rnd.Next(1000);
                if(Data == i) { 
                    ReturnData.Add(Data);
                    var t = FunctionB(i);
                }
            }
            return ReturnData;

        }
        public async Task<bool> FunctionB(int value)
        {
            await Task.Delay(100);
            return true;
        }
    }
}
