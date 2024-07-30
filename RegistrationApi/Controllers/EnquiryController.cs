using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Repository;
using RegistrationApi.Services;
using System.Text.RegularExpressions;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiry _enquiryRepository;

        public EnquiryController(IEnquiry enquiryRepository)
        {
            _enquiryRepository = enquiryRepository;
        }

        [HttpGet]
        public  IActionResult GetEnquiries()
        { 
           var er= _enquiryRepository.GetAllEnquiry().ToList();
            return Ok(er);
        }

        [HttpPost]
        public  IActionResult CreateEnquiry(Enquiry enquiry)
        {
            
            _enquiryRepository.AddEnquiry(enquiry);
            _enquiryRepository.SaveChanges();

            return Ok("added successfuly");
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnquiry(int id,Enquiry enquiry)
        {
            var existingEnquiry= _enquiryRepository.GetEnquiryById(id);
            if (existingEnquiry == null)
            {
                return NotFound("Material not found.");
            }
            existingEnquiry.Subject = enquiry.Subject;
            existingEnquiry.Status = enquiry.Status;
           

            _enquiryRepository.UpdateEnquiry(existingEnquiry);

            return Ok(existingEnquiry);
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteEnquiry(int id)
        {
            var existingEnquiry =  _enquiryRepository.GetEnquiryById(id);
            if (existingEnquiry == null)
            {
                return NotFound();
            }

             _enquiryRepository.DeleteEnquiry(id);
            return NoContent();
        }
    }
}
