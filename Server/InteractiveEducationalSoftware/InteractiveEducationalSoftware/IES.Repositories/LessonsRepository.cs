using Dapper;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.BusinessModels;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class LessonsRepository : CommonRepository<LessonEntity, int>, ILessonsRepository
    {
        public LessonsRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<LessonListItem> SelectViewModels()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var viewModels = db.Query<LessonListItem>(
                    @"SELECT 
                        [LessonId],
                        [Chapters].[Name] AS Chapter,
                        [Lessons].[Name],
                        [Lessons].[Description]
                      FROM Lessons INNER JOIN Chapters ON [Lessons].[ChapterId] = [Chapters].[ChapterId]                            
                ").ToList();
                db.Close();

                return viewModels;
            }
        }

        public StudentLessonProgress GetLessonProgress(int lessonId, int studentId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var progress = db.Query<StudentLessonProgress>(@"SELECT * FROM StudentLessonsProgress WHERE [LessonId] = @lessonId AND [StudentId] = @studentId", new { lessonId, studentId }).FirstOrDefault();
                db.Close();
                return progress;
            }
        }
    }
}