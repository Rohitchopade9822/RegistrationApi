using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourses();

        void AddCourses(Course course);

        Task<Course> GetCourseByIdAsync(int id);

        Task UpdateCourseAsync(Course course);

        Task SaveChangesAsync();

        Task DeleteCourseAsync(int id);

    }
}
