using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IUsersRepository : ICommonRepository<User, int>
    {
        public User Login(string username, string password);
    }
}
