using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface ITestsService : IService<Test, int>
    {
        public Test GenerateTest();
    }
}
