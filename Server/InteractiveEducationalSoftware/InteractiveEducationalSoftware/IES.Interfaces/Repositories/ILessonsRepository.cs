using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Repositories
{
    public interface ILessonsRepository : IRepository<LessonEntity, int>
    {
        public List<LessonListItem> SelectViewModels();
    }
}
