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
                _context= myAppDbContext;
        }

        public IEnumerable<Course> GetCourse()
        {
            return _context.Courses.ToList();
        }

        public void addCourse(Course course)
        {
            course.courseId = GetmaxId();
            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void deleteCourse(int courseId)
        {
            var courseid = _context.Materials.Find(courseId);
            if (courseid != null)
            {
                _context.Materials.Remove(courseid);
                _context.SaveChanges();
            }
        }

        public int GetmaxId()
        {
            var maxcourseId = _context.Courses.Max(m => (int?)m.courseId) ?? 0;
            return maxcourseId + 1;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }
    }
}
