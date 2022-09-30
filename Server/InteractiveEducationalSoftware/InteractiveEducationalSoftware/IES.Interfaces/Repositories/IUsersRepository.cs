using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<User, int>
    {
        public User Login(string username, string password);
    }
}
