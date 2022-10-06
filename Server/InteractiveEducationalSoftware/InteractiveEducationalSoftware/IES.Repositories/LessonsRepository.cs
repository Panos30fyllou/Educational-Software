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
    }
}