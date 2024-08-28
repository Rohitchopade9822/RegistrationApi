using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollment _enrollmentService;

        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollmentService = enrollment;   
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var en = _enrollmentService.GetAllEnrollments();
                return Ok(en);
            }
            
             catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving materials: {ex.Message}");
            }
        }
       
    }
}
