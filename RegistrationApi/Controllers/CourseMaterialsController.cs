using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Services;
using System.Linq;
namespace RegistrationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseMaterialsController : ControllerBase
    {

        private readonly ICourseMaterialRepository _courseMaterialRepository; 

        public CourseMaterialsController(ICourseMaterialRepository courseMaterialRepository)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseMaterials(int courseId)
        {
            var courseMaterials = await _courseMaterialRepository.GetCourseMaterials( courseId);
            if (courseMaterials.Any())
            {
                return Ok(courseMaterials);
            }
            else
            {
                return NotFound(); 
            }
            

        }
    }
}


