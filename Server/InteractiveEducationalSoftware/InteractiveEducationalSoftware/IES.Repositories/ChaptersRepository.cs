using Dapper;
using Dapper.Contrib.Extensions;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class ChaptersRepository : IChaptersRepository
    {
        public string ConnectionString { get; set; }

        public ChaptersRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Chapter> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var chapters = db.GetAll<Chapter>().ToList();
                db.Close();

                return chapters;
            }
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

        public Chapter SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var chapter = db.Get<Chapter>(id);
                db.Close();

                return chapter;
            }
        }

        public void Insert(Chapter chapter)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(chapter);
                db.Close();
            }
        }

        public void Update(Chapter chapter)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(chapter);
                db.Close();
            }
        }

        public void Delete(Chapter chapter)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(chapter);
                db.Close();
            }
        }
    }
}