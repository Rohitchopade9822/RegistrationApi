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

        public UserController(IUser user)
        {
            _user = user;   
        }

        [HttpGet]
        public IActionResult GetallUser()
        {
            var us = _user.GetUsers();
            return Ok(us);

        }

		[HttpGet]
		public IActionResult GetUserbyid(int id)
		{
			var us = _user.GetUserbyid(id);
			return Ok(us);

		}

		[HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
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
