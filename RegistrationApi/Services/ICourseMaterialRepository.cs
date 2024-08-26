using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface ICourseMaterialRepository
    {
        Task<IEnumerable<Course>> GetCourseMaterials();
    }
}
