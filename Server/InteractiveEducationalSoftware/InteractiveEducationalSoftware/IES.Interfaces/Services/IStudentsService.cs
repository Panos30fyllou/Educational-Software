using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface IStudentsService : ICommonService<Student, int>
    {
        void UpdateProgress(StudentLessonProgress progress);
        decimal GetProgress(int studentId);
        decimal GetAverageScore(int studentId);
        public decimal GetHighScore(int studentId);
    }
}
