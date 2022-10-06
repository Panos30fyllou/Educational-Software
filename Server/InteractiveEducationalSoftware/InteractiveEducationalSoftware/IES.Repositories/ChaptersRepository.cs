using Dapper;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class ChaptersRepository : CommonRepository<Chapter, int>, IChaptersRepository
    {
        public ChaptersRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Chapter> SelectFive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var chapters = db.Query<Chapter>(
                    @"SELECT TOP 5 
                        [AnswerId],
                        [Description]
	                FROM Answers 
                    ORDER BY NEWID()").ToList();
                db.Close();

                return chapters;
            }
        }
    }
}