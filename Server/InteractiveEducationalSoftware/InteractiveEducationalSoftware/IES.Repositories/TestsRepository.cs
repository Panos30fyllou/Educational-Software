using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data.SqlClient;
using System.Data;
using IES.Models.BusinessModels;
using Dapper;

namespace IES.Repositories
{
    public class TestsRepository : CommonRepository<Test, int>, ITestsRepository
    {
        public TestsRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public void SaveTestResult(TestResult result)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Query(@"
                    INSERT INTO StudentTestsProgress ([StudentId], [Date], [Score], [StartingChapterId], [EndingChapterId])
                    VALUES(@StudentId, @Date, @Score, @StartingChapterId, @EndingChapterId)",
                    new
                    {
                        StudentId = result.StudentId,
                        Date = result.Date,
                        Score = result.Score,
                        StartingChapterId = result.StartingChapterId,
                        EndingChapterId = result.EndingChapterId
                    }).ToList();
                db.Close();
            }
        }
    }
}