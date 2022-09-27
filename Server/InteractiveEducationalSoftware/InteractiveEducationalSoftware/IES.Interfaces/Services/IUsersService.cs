using IES.Models;

namespace IES.Interfaces.Services
{
    public interface IUsersService : IService<User, int>
    {
        public User Login(string username, string password);
    }
}
