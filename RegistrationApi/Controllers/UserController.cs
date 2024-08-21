using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{

    [Route("api/[controller]/[action]")]

    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger,IUser user)
        {
            _logger = logger;
            _user = user;
        }

       
        [HttpGet]
        public IActionResult GetallUser()
        {
            //_logger.LogWarning("Get user material excuting");
            var us = _user.GetUsers();
            return Ok(us);

        }

		[HttpGet]
		public IActionResult GetUserbyid(int id)
		{
            _logger.LogInformation("get use api start excuting");
			var us = _user.GetUserbyid(id);

			return Ok(us);

		}

		[HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                _logger.LogInformation("Post use api start excuting");
                _user.AddUser(user);
                _user.Savechanges();
                 return Ok("succesfull");
            }

            catch (Exception ex) 
            {
                return Ok(ex.Message);
            }
                                      
        }

        [HttpPut]
        public IActionResult UpdateUser(int id,User user)
        {
            
                var exituser = _user.GetUserbyid(id);

                if(exituser==null)
                {
                    return NotFound ("User not found.");
                }
            exituser.Email = user.Email;
            exituser.Password = user.Password;
            exituser.Username = user.Username;
            exituser.Role = user.Role;
            exituser.Password=user.Password;
            exituser.MobileNumber = user.MobileNumber;
            exituser.ProfileImage = user.ProfileImage;


            _user.UpdateUser(exituser);
                return Ok(exituser);

        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _user.DeleteUser(id);
            _user.Savechanges();
            return Ok("deleted");
        }
    }
}
