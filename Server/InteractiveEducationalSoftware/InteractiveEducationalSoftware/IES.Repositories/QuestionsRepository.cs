using Dapper;
using DapperExtensions;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        public string ConnectionString { get; set; }

        public QuestionsRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Question> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var questions = db.GetList<Question>().ToList();
                db.Close();

                return questions;
            }
        }

        public List<Question> SelectFive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var questions = db.Query<Question>(
                    @"SELECT TOP 5 
                        [AnswerId],
                        [Description]
	                FROM Answers 
                    ORDER BY NEWID()").ToList();
                db.Close();

                return questions;
            }
        }

        public Question SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var question = db.Get<Question>(id);
                db.Close();

                return question;
            }
        }

        public void Insert(Question question)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(question);
                db.Close();
            }
        }

        public void Update(Question question)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(question);
                db.Close();
            }
        }

        public void Delete(Question question)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(question);
                db.Close();
            }
        }
    }
}