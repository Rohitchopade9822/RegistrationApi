using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface ICourseMaterialRepository
    {
        Task<IEnumerable<CourseMaterialViewModel>> GetCourseMaterials();
    }
}
