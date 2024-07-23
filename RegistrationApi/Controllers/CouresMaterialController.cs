using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApi.Repository;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouresMaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;

        public CouresMaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseMaterialViewModel>>> GetCourses()
        {
            var courses = await _materialRepository.CourseMaterialViewModel
                .Select(c => new CourseMaterialViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Category = c.Category,
                    Level = c.Level
                })
                .ToListAsync();

            return Ok(courses);
        }
    }
}
