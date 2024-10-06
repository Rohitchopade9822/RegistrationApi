using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Services;
using System.Text.Json;

namespace RegistrationApi.Controllers
{


    namespace RegistrationApi.Controllers
    {
        [Route("api/[controller]/[action]")]
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

                var userId = HttpContext.Session.GetInt32("userId");

                if (userId == null)
                {
                    return Unauthorized(); // Or handle the case where the user is not logged in
                }

                var materials =  _materialRepository.GetMaterialById(userId.Value);
                return Ok(materials);

                //try
                //{
                //    var materials = _materialRepository.GetMaterials();
                //    return Ok(materials);
                //}
                //catch (Exception ex)
                //{
                //    return StatusCode(500, $"An error occurred while retrieving materials: {ex.Message}");
                //}
            }

            [HttpGet]
            [HttpGet("{userId}")]
            public IActionResult IdbyMaterial( int userId)
            {
                try
                {
                   
                    var materialbyid = _materialRepository.GetMaterialById(userId);
                    return Ok(materialbyid);
                }
                catch
                {
                    return StatusCode(500, $"An error occurred while retrieving materials");
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
            [HttpPut("{id}")]
            public IActionResult UpdateMaterial(int id, Material material) 
            {
                var existingMaterial = _materialRepository.GetMaterialById(id);

                if (existingMaterial == null)
                {
                    return NotFound("Material not found.");
                }

                existingMaterial.title=material.title;
                existingMaterial.description = material.description;
                existingMaterial.contentType=material.contentType;

                _materialRepository.UpdateMaterial(existingMaterial);

                return Ok(existingMaterial);
            }
            [HttpDelete]
            public IActionResult DeleteMaterial(int id)
            {
                _materialRepository.DeleteMaterial(id);
                return Ok("deleted");
            }
            

           
        }
    }

}
