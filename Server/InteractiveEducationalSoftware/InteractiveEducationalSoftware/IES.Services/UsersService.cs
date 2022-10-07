using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _userRepository;
        private IStudentsRepository _studentsRepository;
        private ITeachersRepository _teachersRepository;

        public string ConnectionString { get; set; }

        public UsersService(IUsersRepository userRepository, IStudentsRepository studentsRepository, ITeachersRepository teachersRepository)
        {
            _userRepository = userRepository;
            _studentsRepository = studentsRepository;
            _teachersRepository = teachersRepository;
        }

        public User Login(LoginRequest request)
        {
            var result = _userRepository.Login(request.Username, request.Password);
            if (result is null)
            {
                throw new BusinessException("Wrong Password");
            }
            return result;
        }

        public void Register(RegisterRequest request)
        {
            if (request == null)
                throw new BusinessException();
            var id = _userRepository.Insert(new User() { Username = request.Username, Password = request.Password, Email = request.Email, Role = request.Role });
            if (request.Role == UserRole.Student)
                _studentsRepository.Insert(new Student() { UserId = id, Name = request.Name, Surname = request.Surname });
            if (request.Role == UserRole.Teacher)
                _teachersRepository.Insert(new Teacher() { UserId = id, Name = request.Name, Surname = request.Surname });
        }

        public Profile GetUserProfile(int id)
        {
            var user = _userRepository.SelectById(id);
            Profile profile = new Profile()
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
            if (user.Role == UserRole.Student)
            {
                Student student = _studentsRepository.SelectByUserId(id);
                profile.Name = student.Name;
                profile.Surname = student.Surname;
                profile.RoleId = student.StudentId;
            }
            if (user.Role == UserRole.Teacher)
            {
                Teacher teacher = _teachersRepository.SelectByUserId(id);
                profile.Name = teacher.Name;
                profile.Surname = teacher.Surname;
                profile.RoleId = teacher.TeacherId;
            }
            return profile;
        }

        public void UpdateProfile(Profile profile)
        {
            if(profile == null)
            {
                throw new BusinessException();
            }
            _userRepository.Update(profile);
            if (profile.Role == UserRole.Student)
                _studentsRepository.UpdateStudentProfileByUserId(profile);
            if (profile.Role == UserRole.Teacher)
                _teachersRepository.UpdateTeacherProfileByUserId(profile);

        }

    }

}
