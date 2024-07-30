using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensibility;
using RegistrationApi.DBModel;
using RegistrationApi.Repository;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly FeedbackRepository _FeedbackRepository;

        public FeedBackController(FeedbackRepository feedbackRepository)
        {
            _FeedbackRepository = feedbackRepository;
        }
        [HttpGet]
        [Route("GetFeedback")]
        public IActionResult GetFeedback()
        {
            var fd = _FeedbackRepository.GetFeedbacks();
            return Ok(fd);
        }
        [HttpPost]
        [Route("AddFeedback")]
        public IActionResult AddFeedback(Feedback feedback)
        {
            try
            {
                _FeedbackRepository.AddFeedback(feedback);

                return Ok("Feedback add successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        [Route("AddFeedback")]
        public IActionResult Updatefeedback(int id ,Feedback feedback)
        {
            if (feedback == null || id != feedback.FeedbackId)
            {
                return BadRequest("Course data is invalid.");
            }

            try
            {
                var existingfeedback = _FeedbackRepository.GetFeedbackById(id);

                if (existingfeedback == null)
                {
                    return NotFound("Course not found.");
                }

                // Update properties of the existing course with new values
                existingfeedback.FeedbackText = feedback.FeedbackText;
                

                // Call the repository method to update the course
                _FeedbackRepository.UpdateFeedback(existingfeedback);

                return Ok(existingfeedback);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework if available)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating Feedback: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult deletefeedback(int id)
        {

            _FeedbackRepository.DeleteFeedback(id);
            return Ok("deleted");


        }

    }

}
