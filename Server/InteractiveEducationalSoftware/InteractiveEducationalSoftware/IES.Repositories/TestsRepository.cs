using Dapper;
using DapperExtensions;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class TestsRepository : ITestsRepository
    {
        public string ConnectionString { get; set; }

        public TestsRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Test> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var tests = db.GetList<Test>().ToList();
                db.Close();

                return tests;
            }
        }

        public Test SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var test = db.Get<Test>(id);
                db.Close();

                return test;
            }
        }

        public void Insert(Test test)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(test);
                db.Close();
            }
        }

        public void Update(Test test)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(test);
                db.Close();
            }
        }

        public void Delete(Test test)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(test);
                db.Close();
            }
        }
    }
}