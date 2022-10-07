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

        public List<Question> SelectFive(int startingChapterId, int endingChapterId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var questions = db.Query<Question>(@"
                    SELECT TOP 5 
                        [QuestionId],
                        [Description],
                        [CorrectAnswerId],
                        [Points]
	                FROM Questions WHERE [ChapterId] >= @startingChapterId AND [ChapterId] <= @endingChapterId
                    ORDER BY NEWID()", new { startingChapterId, endingChapterId }).ToList();

                questions.ForEach(q => q.PossibleAnswers = db.Query<Answer>(@"
                        SELECT TOP 4
                            [Answers].[AnswerId],
	                        [Answers].[Description]
                        FROM QARelations INNER JOIN Answers ON [QARelations].AnswerId = [Answers].AnswerId 
                        WHERE QuestionId = @QuestionId
                        ORDER BY NEWID()", new { QuestionId = q.QuestionId }).ToList());
                db.Close();

                return questions;
            }
        }

        public void InsertWrongAnswerdQuestions(int studentId, List<int> questionIds, DateTime date)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                foreach (var question in questionIds)
                {
                    db.Query(@"
                    INSERT INTO WrongQuestions
                    VALUES(@studentId, @questionId, @date)", new { studentId, questionId = question, date }).ToList();
                }
                db.Close();

            }
        }
    }
}