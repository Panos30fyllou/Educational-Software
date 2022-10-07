using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using IES.Models.DataModels;
using IES.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace IES.WebHost.Controllers
{
    [EnableCors("*", "*", "*")]
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private ILessonsService _lessonService;


        public LessonsController(ILessonsService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult SelectListItems()
        {
            List<LessonListItem> Lessons;
            try
            {
                Lessons = _lessonService.SelectLessonListItems();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(Lessons);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult SelectById(int id)
        {
            Lesson lesson;
            try
            {
                lesson = _lessonService.SelectById(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(lesson);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllChapters()
        {
            List<Chapter> chapters;
            try
            {
                chapters = _lessonService.GetAllChapters();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(chapters);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Add(LessonEntity lesson)
        {
            try
            {
                _lessonService.AddLessonByTeacher(lesson);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetLessonProgress(int lessonId, int studentId)
        {
            StudentLessonProgress progress;
            try
            {
                progress = _lessonService.GetLessonProgress(lessonId, studentId);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(progress);
        }
    }
}
