using IES.Interfaces.Services;
using IES.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PhoneCatalog.WebHost.Controllers
{
    [EnableCors("*")]
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
        public ActionResult Get()
        {
            Test test;
            try
            {
                test = _testService.GenerateTest();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(test);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Add(Test test)
        {
            try
            {
                _testService.Insert(test);
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
                _testService.Delete(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult Update(Test test)
        {
            try
            {
                _testService.Update(test);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult SelectById(int id)
        {
            Test test;
            try
            {
                test = _testService.SelectById(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(test);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectViewModelById(int id)
        //{
        //    Test test;
        //    try
        //    {
        //        test = _testService.SelectViewModelById(id);
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(test);
        //}

        [HttpGet]
        [Route("[action]")]
        public ActionResult SelectAll()
        {
            List<Test> tests;
            try
            {
                tests = _testService.SelectAll();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(tests);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectAllViewModels()
        //{
        //    List<TestViewModel> tests;
        //    try
        //    {
        //        tests = _testService.SelectAllViewModels();
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(tests);
        //}
    }
}
