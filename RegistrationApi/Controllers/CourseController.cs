using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.DBModel;
using RegistrationApi.Repository;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ICourse _courses;

        public CourseController(ICourse course)
        {
            _courses = course;
        }

        [HttpGet]
        [Route("GetCourses")]
        public IActionResult GetCourses()
        {
            try
            {
                var cr = _courses.GetCourses();
                return Ok(cr);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        [Route("AddCourses")]
        public IActionResult PostCourses(Course course)
        {
            try
            {
                _courses.AddCourses(course);
                _courses.SaveChangesAsync();
                return Ok("Add Successfuly");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            if (updatedCourse == null || id != updatedCourse.courseId)
            {
                return BadRequest("Course data is invalid.");
            }

            try
            {
                var existingCourse = await _courses.GetCourseByIdAsync(id);

                if (existingCourse == null)
                {
                    return NotFound("Course not found.");
                }

                // Update properties of the existing course with new values
                existingCourse.title = updatedCourse.title;
                existingCourse.description = updatedCourse.description;
                existingCourse.courseStartDate = updatedCourse.courseStartDate;
                existingCourse.courseEndDate = updatedCourse.courseEndDate;
                existingCourse.userId = updatedCourse.userId;
                existingCourse.category = updatedCourse.category;
                existingCourse.level = updatedCourse.level;

                // Call the repository method to update the course
                await _courses.UpdateCourseAsync(existingCourse);

                return Ok(existingCourse);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework if available)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating course: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCourse(int id)
        {
            try
            {
                await _courses.DeleteCourseAsync(id);

                return Ok("deleted succefully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting course: {ex.Message}");
            }
           
        }

    }
}
