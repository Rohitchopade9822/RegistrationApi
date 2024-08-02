//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using RegistrationApi.DBModel;
//using RegistrationApi.Services;

//namespace RegistrationApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly MyAppDbContext _userInfoContext;
//        private readonly IAuthenticationService _authentication;


//        public AuthenticationController(MyAppDbContext userInfoContext, IAuthenticationService authentication)
//        {
//            _userInfoContext = userInfoContext;
//            _authentication = authentication;
//        }



//        [HttpPost]
//        [Route("UserLogin")]
//        public IActionResult UserLogin(LoginViewModel user)
//        {
//            IActionResult response = Unauthorized();
//            var validateUser = _userInfoContext.Userinfos.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
//            if (validateUser != null)
//            {
//                var token = _authentication.GenerateToken(validateUser);
//                return Ok(new { token = token });
//            }

//            return response;
//        }
//    }
//}