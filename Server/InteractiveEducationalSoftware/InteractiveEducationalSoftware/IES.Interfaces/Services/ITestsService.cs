using IES.Models;

namespace IES.Interfaces.Services
{
    public interface ITestsService : IService<Test, int>
    {
        public Test GenerateTest();
    }
}
