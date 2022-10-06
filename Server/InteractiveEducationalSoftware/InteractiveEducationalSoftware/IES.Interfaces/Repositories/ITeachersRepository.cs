using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface ITeachersRepository : ICommonRepository<Teacher, int>
    {
        public Teacher SelectByUserId(int userId);
        public void UpdateTeacherProfileByUserId(Profile profile);
    }
}
