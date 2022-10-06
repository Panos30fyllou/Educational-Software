using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using IES.Models.DataModels;

namespace IES.Services
{
    public class LessonsService : ILessonsService
    {
        private ILessonsRepository _lessonRepository;
        private IChaptersRepository _chapterRepository;

        public string ConnectionString { get; set; }

        public LessonsService(ILessonsRepository lessonRepository, IChaptersRepository chapterRepository)
        {
            _lessonRepository = lessonRepository;
            _chapterRepository = chapterRepository;
        }


        public List<LessonListItem> SelectLessonListItems()
        {
            return _lessonRepository.SelectViewModels();
        }


        public void Delete(int id)
        {
            var lesson = _lessonRepository.SelectById(id);
            if (lesson == null)
                throw new BusinessException("Lesson not found!");
            _lessonRepository.Delete(lesson);
        }


        public Lesson SelectById(int id)
        {
            var lessonEntity = _lessonRepository.SelectById(id);
            if (lessonEntity == null)
                throw new BusinessException("Lesson not found!");

            Lesson lesson = new()
            {
                LessonId = lessonEntity.LessonId,
                Name = lessonEntity.Name,
                Description = lessonEntity.Description,
                Material = lessonEntity.Material
            };
            lesson.Chapter = _chapterRepository.SelectById(lessonEntity.ChapterId).Name;
            return lesson;
        }


        public void Update(Lesson lesson)
        {
        }


        public List<Lesson> SelectAll()
        {
            throw new NotImplementedException();
        }

        public int AddLessonByTeacher(LessonEntity lesson)
        {
            lesson.Material = lesson.Material.Replace(Environment.NewLine, "<br />");
            return _lessonRepository.Insert(lesson);
        }

        public int Insert(Lesson lesson)
        {
            throw new NotImplementedException();
        }
    }

}
