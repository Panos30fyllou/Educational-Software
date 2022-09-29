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
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            User user2;
            try
            {
                user2 = _userService.Login(loginRequest.Username, loginRequest.Password);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(user2);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Add(User user)
        {
            try
            {
                _userService.Insert(user);
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
                _userService.Delete(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult Update(User user)
        {
            try
            {
                _userService.Update(user);
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
            User user;
            try
            {
                user = _userService.SelectById(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(user);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectViewModelById(int id)
        //{
        //    User user;
        //    try
        //    {
        //        user = _userService.SelectViewModelById(id);
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(user);
        //}

        [HttpGet]
        [Route("[action]")]
        public ActionResult SelectAll()
        {
            List<User> users;
            try
            {
                users = _userService.SelectAll();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(users);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult SelectAllViewModels()
        //{
        //    List<UserViewModel> users;
        //    try
        //    {
        //        users = _userService.SelectAllViewModels();
        //    }
        //    catch (BusinessException e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    return Ok(users);
        //}
    }
}
