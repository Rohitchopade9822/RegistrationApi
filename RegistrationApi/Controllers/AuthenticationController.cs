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

           // var result = _passwordHasher.Verify(validateUser.Password, userModel.Password);
            if (validateUser==null)
            {
                throw new Exception("Username and Password is not correct.");
            }

            if (validateUser != null)
            {
                var token = _authentication.GenerateToken(validateUser);
                return Ok(tokenstring = token);
            }

            return response;
        }
    }
}