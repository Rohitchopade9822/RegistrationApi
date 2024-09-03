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

            [HttpGet]
            public IActionResult IdbyMaterial(int id)
            {
                try
                {
                    var materialbyid = _materialRepository.GetMaterialById(id);
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
