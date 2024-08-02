using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
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
       
        [HttpPost]
        public IActionResult AddUsers(User user)
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
                    return NotFound("User not found.");
                }
                exituser.Email = user.Email;
                exituser.Password = user.Password;
                exituser.Username= user.Username;

                _user.UpdateUser(exituser);
                return Ok(exituser);

            
           
        }
    }
}
