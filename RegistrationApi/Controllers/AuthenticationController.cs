using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var userId = validateUser.UserId;
            if (userId != null)
            {
                return RedirectToAction("IdbyMaterial", "Materials", new { userId = userId });
            }
            //var result = _passwordHasher.Verify(validateUser.Password, userModel.Password);
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
               
                // Assuming UserId is the property for the user ID
               
                var token = _authentication.GenerateToken(validateUser);
                return Ok (new { token });
            }

            return response;
          
        }
    }
}