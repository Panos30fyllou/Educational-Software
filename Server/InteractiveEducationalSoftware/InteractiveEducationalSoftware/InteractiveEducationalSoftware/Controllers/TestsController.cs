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
    public class TestsController : ControllerBase
    {
        private ITestsService _testService;

        public TestsController(ITestsService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult Generate(int startingChapterId, int endingChapterId)
        {
            Test test;
            try
            {
                test = _testService.GenerateTest(startingChapterId, endingChapterId);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(test);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult SubmitResult([FromBody] TestResult result)
        {
            try
            {
                _testService.SubmitResult(result);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        //[HttpGet]
        //public ActionResult Get()
        //{
        //    Test test;
        //    try
        //    {
        //        test = _testService.GenerateTest();
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(test);
        //}

        //[HttpPost]
        //[Route("[action]")]
        //public ActionResult Add(Test test)
        //{
        //    try
        //    {
        //        _testService.Insert(test);
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok();
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectById(int id)
        //{
        //    Test test;
        //    try
        //    {
        //        test = _testService.SelectById(id);
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(test);
        //}
    }
}
