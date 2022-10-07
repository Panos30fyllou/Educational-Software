using IES.Interfaces.Services;
using IES.Models;
using IES.Models.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace IES.WebHost.Controllers
{
    [EnableCors("*", "*", "*")]
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentsService _studentService;

        public StudentsController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CompletedLesson([FromBody] StudentLessonProgress progress)
        {
            try
            {
                _studentService.UpdateProgress(progress);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetProgress(int id)
        {
            decimal progressPercentage;
            try
            {
                progressPercentage = _studentService.GetProgress(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(progressPercentage);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAverageTestScore(int id)
        {
            decimal averageScore;
            try
            {
                averageScore = _studentService.GetAverageScore(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(averageScore);
        }
    }
}
