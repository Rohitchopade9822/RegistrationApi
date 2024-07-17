using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;


namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public UserController(MyAppDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        [Route("Getuser")]
        public IActionResult getuser()
        {
            try
            {
                var users = _context.Userinfos.ToList();

                // check for null values in properties before returning
                var userswithoutnulls = users.Select(u => new
                {
                    userid = u.UserId,
                    username = u.Username,
                    password = u.Password,
                   
                }).ToList();

                return Ok(userswithoutnulls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error occurred while retrieving users: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserDto UserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);  // Return validation errors if model state is not valid
                }

                // Retrieve the maximum UserId from the database
                var maxUserId = _context.Userinfos.Max(u => (int?)u.UserId) ?? 0; // Assuming UserId is int type

                // Increment maxUserId by 1 to generate a new UserId
                var newUserId = maxUserId + 1;

                // Check if username already exists
                var objUser = _context.Userinfos.FirstOrDefault(x => x.Username == UserDto.Username && x.Password == UserDto.Password);
                if (objUser != null)
                {
                    return BadRequest("User already exists");
                }

                // Create a new Userinfo entity with the generated UserId
                var newUser = new Userinfo
                {
                    UserId = newUserId,
                    Username = UserDto.Username,
                    Password = UserDto.Password,

                };

                // Add user to DbContext and save changes
                _context.Userinfos.Add(newUser);
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

