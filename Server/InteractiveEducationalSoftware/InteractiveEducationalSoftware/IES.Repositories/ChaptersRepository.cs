using Dapper;
using DapperExtensions;
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
                var lessons = db.GetList<Chapter>().ToList();
                db.Close();

                return lessons;
            }
        }

        public List<Chapter> SelectFive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var lessons = db.Query<Chapter>(
                    @"SELECT TOP 5 
                        [AnswerId],
                        [Description]
	                FROM Answers 
                    ORDER BY NEWID()").ToList();
                db.Close();

                return lessons;
            }
        }

        public Chapter SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var lesson = db.Get<Chapter>(id);
                db.Close();

                return lesson;
            }
        }

        public void Insert(Chapter lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(lesson);
                db.Close();
            }
        }

        public void Update(Chapter lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(lesson);
                db.Close();
            }
        }

        public void Delete(Chapter lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(lesson);
                db.Close();
            }
        }
    }
}