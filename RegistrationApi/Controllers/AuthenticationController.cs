using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly MyAppDbContext _userInfoContext;
        private readonly IAuthenticationServices _authentication;
        

        public AuthenticationController(MyAppDbContext userInfoContext, IAuthenticationServices authentication)
        {
            _userInfoContext = userInfoContext;
            _authentication = authentication;
            
        }



        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(LoginViewModel user)
        {
            string tokenstring = string.Empty;

            IActionResult response = Unauthorized();

            var validateUser =  _userInfoContext.Users.FirstOrDefault(e => e.Password == user.Password);
            
            
            if (validateUser==null)
            {
                return BadRequest("Invalid username or password.");
            }


            //if (validateUser != null)
            //{
            //    //var token = _authentication.GenerateToken(validateUser);
            //    //return Ok(tokenstring = token);
            //}
           
            if (validateUser != null)
            {

               
                var token = _authentication.GenerateToken(validateUser);
                tokenstring = token;

                var userData = _userInfoContext.Users.FirstOrDefault(u => u.UserId == validateUser.UserId);
                
              //  user.UserData = validateUser;
                var reponseobject = new
                {
                    Token = tokenstring,
                   
                };

                return Ok (reponseobject);
            }

            return response;
          
        }
    }
}