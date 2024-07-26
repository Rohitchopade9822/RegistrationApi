using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Services;
using System.Linq;
namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMaterialsController : ControllerBase
    {

        private readonly ICourseMaterialRepository _courseMaterialRepository;

        public CourseMaterialsController(ICourseMaterialRepository courseMaterialRepository)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseMaterials()
        {
            var courseMaterials = await _courseMaterialRepository.GetCourseMaterials();
            return Ok(courseMaterials);
        }
    }
}


