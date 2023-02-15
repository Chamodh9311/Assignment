using static Assignment.Model.AssignmentModel;

namespace Assignment.Service
{
    public interface IAssignmentService
    {
        public  Task<string> StringReverser(InverseText Request);
        public string GetMD5HashFromFile(string fileName);
        public Task<List<Market>> PageAssets();
        public List<int> FunctionA();
    }
}
