using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface ITestsRepository : ICommonRepository<Test, int>
    {
        public void SaveTestResult(TestResult result);
    }
}
