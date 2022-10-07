using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using IES.Models.BusinessModels;
using Dapper.Contrib.Extensions;
using System;

namespace IES.Repositories
{
    public class StudentsRepository : CommonRepository<Student, int>, IStudentsRepository
    {
        public StudentsRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public Student SelectByUserId(int userId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var student = db.QueryFirstOrDefault<Student>(@"SELECT * FROM Students WHERE [UserId]=@userId", new { userId });
                db.Close();
                return student;
            }
        }

        public void UpdateStudentProfileByUserId(Profile profile)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.QueryFirstOrDefault<Student>(@"
                    UPDATE Students 
                    SET [Name] = @Name, [Surname] = @Surname
                    WHERE [UserId] = @userId", new { Name = profile.Name, Surname = profile.Surname, UserId = profile.UserId });
                db.Close();
            }
        }

        public void UpdateProgress(StudentLessonProgress progress)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Query(@"
                    IF(SELECT 1 FROM StudentLessonsProgress WHERE [StudentId] = @StudentId AND [LessonId] = @LessonId) IS NULL
                        BEGIN
	                        INSERT INTO StudentLessonsProgress
	                        VALUES(@StudentId, @LessonId, 1, GETUTCDATE())
	                    END
                    ELSE
                        BEGIN
	                        UPDATE StudentLessonsProgress
	                        SET [Completed] = @Completed, [DateCompleted] = @DateCompleted
	                        WHERE [StudentId] = @StudentId AND [LessonId] = @LessonId
	                    END
                ", new { StudentId = progress.StudentId, LessonId = progress.LessonId, Completed = progress.Completed, DateCompleted = progress.DateCompleted });
                db.Close();
            }
        }

        public decimal GetHighScore(int studentId)
        {
            decimal highscore = 0;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                highscore = db.Query<decimal>(@"SELECT MAX([Score])FROM [IES].[dbo].[StudentTestsProgress] WHERE StudentId = @studentId",
                new { studentId }).FirstOrDefault();
                db.Close();
            }
            return highscore;
        }

        public decimal GetAverageScore(int studentId)
        {
            decimal averageScore = 0;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                averageScore = db.Query<decimal>(@"
                        SELECT AVG(Score) FROM StudentTestsProgress WHERE StudentId = @studentId",
                new { studentId }).FirstOrDefault();
                db.Close();
            }
            return averageScore;
        }

        public decimal GetProgress(int studentId)
        {
            decimal percentage;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                percentage = db.Query<decimal>(@"
                    DECLARE @Lessons INT = (SELECT COUNT(*) FROM Lessons)
                    DECLARE @LessonsCompleted INT = (SELECT COUNT(*) FROM StudentLessonsProgress WHERE StudentId = @studentId AND Completed = 1 )
                    
                    IF(@Lessons > 0)
                        SELECT (@LessonsCompleted * 100.0 / @Lessons)
                ", new { studentId }).FirstOrDefault();
                db.Close();
            }
            return percentage;
        }
    }
}