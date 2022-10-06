using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using IES.Models.BusinessModels;

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
    }
}