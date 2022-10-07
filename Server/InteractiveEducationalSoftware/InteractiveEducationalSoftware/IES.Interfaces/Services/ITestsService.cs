using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface ITestsService : ICommonService<Test, int>
    {
        public Test GenerateTest(int startingChapterId, int endingChapterId);
        public void SubmitResult(TestResult result);
    }
}
