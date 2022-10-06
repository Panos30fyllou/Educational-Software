using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models.DataModels;

namespace IES.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository _studentRepository;

        public string ConnectionString { get; set; }

        public StudentsService(IStudentsRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Student SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
