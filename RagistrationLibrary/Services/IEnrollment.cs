using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IEnrollment
    {
        Task<IEnumerable<CourseMaterialViewModel>> GetEnrollment();

    }
}
