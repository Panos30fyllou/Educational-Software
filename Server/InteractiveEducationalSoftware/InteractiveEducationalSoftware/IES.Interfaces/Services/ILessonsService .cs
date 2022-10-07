using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Interfaces.Services
{
    public interface ILessonsService : ICommonService<Lesson, int>
    {
        Lesson SelectById(int id);
        public List<LessonListItem> SelectLessonListItems();
        public int AddLessonByTeacher(LessonEntity lesson);
        List<Chapter> GetAllChapters();
    }
}
