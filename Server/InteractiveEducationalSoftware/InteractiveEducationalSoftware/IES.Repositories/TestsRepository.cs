using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;

namespace IES.Repositories
{
    public class TestsRepository : CommonRepository<Test, int>, ITestsRepository
    {
        public TestsRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }
    }
}