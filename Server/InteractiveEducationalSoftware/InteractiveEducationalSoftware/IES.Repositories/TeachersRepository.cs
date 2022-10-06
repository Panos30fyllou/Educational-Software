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
    public class TeachersRepository : CommonRepository<Teacher, int>, ITeachersRepository
    {
        public TeachersRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public Teacher SelectByUserId(int userId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var teacher = db.QueryFirstOrDefault<Teacher>(@"SELECT * FROM Teachers WHERE [UserId] = @userId", new { userId });
                db.Close();
                return teacher;
            }
        }

        public void UpdateTeacherProfileByUserId(Profile profile)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.QueryFirstOrDefault<Student>(@"
                    UPDATE Teachers 
                    SET [Name] = @Name, [Surname] = @Surname
                    WHERE [UserId] = @userId", new { Name = profile.Name, Surname = profile.Surname, UserId = profile.UserId });
                db.Close();
            }
        }
    }
}