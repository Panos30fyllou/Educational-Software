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
            User user;
            try
            {
                user = _userService.Login(loginRequest);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Register([FromBody] RegisterRequest user)
        {
            try
            {
                _userService.Register(user);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult Update(Profile profile)
        {
            try
            {
                _userService.UpdateProfile(profile);
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
            Profile profile;
            try
            {
                profile = _userService.GetUserProfile(id);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(profile);
        }
    }
}
