using Dapper;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using IES.Repositorys;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class UsersRepository : CommonRepository<User, int>, IUsersRepository
    {
        public UsersRepository(IDbConfig dbConfig) : base(dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public User Login(string username, string password)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var user = db.QueryFirstOrDefault<User>(@"SELECT * FROM Users WHERE [Username]=@username AND [Password]=@password", new { username, password });
                db.Close();
                return user;
            }
        }

        public override void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.QueryFirstOrDefault<Student>(@"
                    UPDATE Users 
                    SET [Username] = @Username, [Email] = @Email
                    WHERE [UserId] = @userId", new { Username = user.Username, Email = user.Email, UserId = user.UserId });
                db.Close();
            }
        }
    }
}