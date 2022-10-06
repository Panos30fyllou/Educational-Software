using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface IStudentsRepository : ICommonRepository<Student, int>
    {
        public Student SelectByUserId(int userId);
        public void UpdateStudentProfileByUserId(Profile profile);
    }
}
