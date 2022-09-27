using IES.Models;

namespace IES.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<User, int>
    {
        public User Login(string username, string password);
    }
}
