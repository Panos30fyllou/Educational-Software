using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using IES.Models.DataModels;
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

        [HttpDelete]
        [Route("[action]")]
        public ActionResult Remove(int id)
        {
            try
            {
                _lessonService.Delete(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

       
        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectViewModelById(int id)
        //{
        //    Lesson Lesson;
        //    try
        //    {
        //        Lesson = _LessonService.SelectViewModelById(id);
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(Lesson);
        //}



    }
}
