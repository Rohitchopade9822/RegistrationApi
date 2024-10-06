using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourse();
        
        void addCourse(Course course);

        void UpdateCourse(Course course);

        void deleteCourse(int courseId);

        Course GetCourseById(int id);

        IEnumerable <Course> GetCourseByUserid(int userId);

        void SaveChanges();


    }
}
