using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface IUsersService : ICommonService<User, int>
    {
        public User Login(LoginRequest loginRequest);
        public void Register(RegisterRequest request);
        public Profile GetUserProfile(int id);
        public void UpdateProfile(Profile profile);
    }
}
