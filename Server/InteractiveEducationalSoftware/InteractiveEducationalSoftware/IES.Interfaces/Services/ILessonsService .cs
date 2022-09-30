using IES.Models.BusinessModels;

namespace IES.Interfaces.Services
{
    public interface ILessonsService : IService<Lesson, int>
    {
        public List<LessonListItem> SelectLessonListItems();
    }
}
