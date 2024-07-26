using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Repository
{
    public class CourseRepository:ICourse
    {
        private readonly MyAppDbContext _context;

        public CourseRepository(MyAppDbContext myAppDbContext)
        {
            _context = myAppDbContext;

        }

        private int GetMaxId()
        {
            var MaxcourseId= _context.Courses.Max(m => (int?)m.courseId) ?? 0;
            return MaxcourseId + 1;
        }

        public void AddCourses(Course course)
        {
            course.courseId = GetMaxId();
           _context.Courses.Add(course);
            
        }

      
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      
        public async Task DeleteCourseAsync(int id)
        {
            var course=_context.Courses.Find(id);
            _context.Courses.Remove(course);
            await SaveChangesAsync();
        }
    }
}
