using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;
using RegistrationApi.Services;


namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _context;
        

        public UserController(IUserRepository context)
        {
           
            _context=context;
        }

        //public UserController(IUserRepository context)
        //{
        //    _context = context;
        //}
        [HttpGet]
        [Route("Getusers")]
        public IActionResult Getusers()
        {
            try
            {
                var users = _context.GetAllUsers();

                // check for null values in properties before returning
                var userswithoutnulls = users.Select(u => new
                {
                    userid = u.UserId,
                    username = u.Username,
                    password = u.Password,
                    email=u.Email,
                    mobileNumber = u.MobileNumber,
                    role=u.Role,
                    profileImage=u.ProfileImage,}).ToList();

                return Ok(userswithoutnulls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occurred while retrieving users: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(Userinfo userinfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);  // Return validation errors if model state is not valid
                }

                // Retrieve the maximum UserId from the database
                var maxUserId = _context.GetusermaxId();

                // Increment maxUserId by 1 to generate a new UserId
                var newUserId = maxUserId + 1;

                // Check if username already exists
                var objUser = _context.GetUserByUsernameAndPassword(userinfo.Username,userinfo.Email);
                if (objUser != null)
                {
                    return BadRequest("User already exists");
                }

                // Create a new Userinfo entity with the generated UserId and other parameters
                var newUser = new Userinfo
                {
                    UserId = newUserId,
                    Username=userinfo.Username,
                    Password = userinfo.Password,
                    Role = userinfo.Role,
                    Email   = userinfo.Email,
                    MobileNumber = userinfo.MobileNumber,
                    ProfileImage = userinfo.ProfileImage,
                    
                };

                // Add user to DbContext and save changes
                _context.AddUser(newUser);
                _context.SaveChanges();

                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }
       


    }
}

