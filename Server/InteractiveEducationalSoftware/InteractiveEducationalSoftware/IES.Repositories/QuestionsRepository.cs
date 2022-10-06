using Dapper;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class QuestionsRepository : CommonRepository<Question, int>, IQuestionsRepository
    {
        public QuestionsRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Question> SelectFive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var questions = db.Query<Question>(
                    @"SELECT TOP 5 
                        [QuestionId],
                        [Description]
	                FROM Questions 
                    ORDER BY NEWID()").ToList();
                db.Close();

                return questions;
            }
        }
    }
}