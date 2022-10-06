using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models.DataModels;

namespace IES.Services
{
    public class TeachersService : ITeachersService
    {
        private ITeachersRepository _teacherRepository;

        public TeachersService(ITeachersRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Teacher SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
