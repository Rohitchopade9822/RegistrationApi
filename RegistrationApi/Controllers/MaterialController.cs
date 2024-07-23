using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Repository;
using System.Text.Json;

namespace RegistrationApi.Controllers
{
  

    namespace RegistrationApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MaterialsController : ControllerBase
        {
            private readonly IMaterialRepository _materialRepository;

            public MaterialsController(IMaterialRepository materialRepository)
            {
                _materialRepository = materialRepository;
            }

            [HttpGet]
            public IActionResult GetMaterials()
            {
                try
                {
                    var materials = _materialRepository.GetMaterials();
                    return Ok(materials);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while retrieving materials: {ex.Message}");
                }
            }
            [HttpPost]
            public IActionResult AddMaterial(Material material) 
            {
                try
                {
                    _materialRepository.AddMaterial(material);
                    _materialRepository.SaveChanges();

                    return Ok("Matrial add Successfully");
                }
                catch (Exception ex) 
                {
                    return  BadRequest(ex);
                }    
              

            }
            [HttpGet]
            public async Task <IActionResult<IEnumerable<Course>>> GetCourses()
            {
                try
                {

                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
    }

}
