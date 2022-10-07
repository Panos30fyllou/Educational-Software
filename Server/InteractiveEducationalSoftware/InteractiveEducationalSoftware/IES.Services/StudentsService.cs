using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models.BusinessModels;

namespace IES.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository _studentRepository;
        private ILessonsRepository _lessonsRepository;

        public string ConnectionString { get; set; }

        public StudentsService(IStudentsRepository studentRepository, ILessonsRepository lessonsRepository)
        {
            _studentRepository = studentRepository;
            _lessonsRepository = lessonsRepository;        }

        public void UpdateProgress(StudentLessonProgress progress)
        {
            _studentRepository.UpdateProgress(progress);
        }

        public decimal GetProgress(int studentId)
        {
            return _studentRepository.GetProgress(studentId);
        }

        public decimal GetAverageScore(int studentId)
        {
            return _studentRepository.GetAverageScore(studentId);
        }

        public decimal GetHighScore(int studentId)
        {
            return _studentRepository.GetHighScore(studentId);
        }
    }
}
