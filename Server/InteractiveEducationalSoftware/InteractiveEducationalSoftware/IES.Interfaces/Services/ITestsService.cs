using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface ITestsService : ICommonService<Test, int>
    {
        public Test GenerateTest();
    }
}
