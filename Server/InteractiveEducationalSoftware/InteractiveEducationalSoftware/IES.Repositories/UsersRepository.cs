using Dapper;
using Dapper.Contrib.Extensions;
using IES.Interfaces;
using IES.Interfaces.Repositories;
using IES.Models.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace IES.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public string ConnectionString { get; set; }

        public UsersRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<User> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var subscribers = db.GetAll<User>().ToList();
                db.Close();

                return subscribers;
            }
        }

        public User SelectById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var subscriber = db.Get<User>(id);
                db.Close();

                return subscriber;
            }
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


        public void Insert(User subscriber)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Insert(subscriber);
                db.Close();
            }
        }

        public void Update(User subscriber)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(subscriber);
                db.Close();
            }
        }

        public void Delete(User subscriber)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(subscriber);
                db.Close();
            }
        }
    }
}