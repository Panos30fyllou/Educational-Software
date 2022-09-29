using Dapper;
using DapperExtensions;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.BusinessModels;
using IES.Models.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        public string ConnectionString { get; set; }

        public LessonsRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<LessonEntity> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var lessons = db.GetList<LessonEntity>().ToList();
                db.Close();

                return lessons;
            }
        }

        public List<LessonEntity> SelectFive()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var lessons = db.Query<LessonEntity>(
                    @"SELECT TOP 5 
                        [AnswerId],
                        [Description]
	                FROM Answers 
                    ORDER BY NEWID()").ToList();
                db.Close();

                return lessons;
            }
        }

        public LessonEntity SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var lesson = db.Get<LessonEntity>(id);
                db.Close();

                return lesson;
            }
        }

        public void Insert(LessonEntity lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(lesson);
                db.Close();
            }
        }

        public void Update(LessonEntity lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(lesson);
                db.Close();
            }
        }

        public void Delete(LessonEntity lesson)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(lesson);
                db.Close();
            }
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