using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;

namespace IES.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _userRepository;

        public string ConnectionString { get; set; }

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            var result = _userRepository.Login(username, password);
            if (result is null)
            {
                throw new BusinessException("Wrong Password");
            }
            return result;
        }

        public void Insert(User user)
        {
            _userRepository.Insert(user);
        }

        public void Delete(int id)
        {
            var user = _userRepository.SelectById(id);
            if (user == null)
                throw new BusinessException("User not found!");
            _userRepository.Delete(user);
        }

        public List<User> SelectAll()
        {
            var usersList = _userRepository.SelectAll();
            return usersList;
        }

        public User SelectById(int id)
        {
            var user = _userRepository.SelectById(id);
            if (user == null)
                throw new BusinessException("User not found!");
            return user;
        }

        public void Update(User user)
        {
            _userRepository.SelectById(user.UserId);
            _userRepository.Update(user);
        }
    }

}
