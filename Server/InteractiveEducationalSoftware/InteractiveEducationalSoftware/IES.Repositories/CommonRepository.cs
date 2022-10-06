using IES.Interfaces;
using IES.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Data;
using Dapper.Contrib.Extensions;


namespace IES.Repositorys
{
    public abstract class CommonRepository<Entity, PKey> : ICommonRepository<Entity, PKey> where Entity : class
    {
        public string ConnectionString { get; set; }

        public CommonRepository(IDbConfig dbConfig)
        {
            ConnectionString = dbConfig.ConnectionString;
        }

        public List<Entity> SelectAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var entitys = db.GetAll<Entity>().ToList();
                db.Close();

                return entitys;
            }
        }

        public Entity SelectById(PKey id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var entity = db.Get<Entity>(id);
                db.Close();

                return entity;
            }
        }

        public int Insert(Entity user)
        {
            int id;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                id = (int)db.Insert<Entity>(user);
                db.Close();
            }
            return id;
        }

        public virtual void Update(Entity entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Update(entity);
                db.Close();
            }
        }

        public void Delete(Entity entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                db.Delete(entity);
                db.Close();
            }
        }
    }
}
