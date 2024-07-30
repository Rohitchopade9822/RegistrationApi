using Microsoft.EntityFrameworkCore.Diagnostics;
using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IEnrollment
    { 
        IEnumerable<Enrollment> GetAllEnrollments();

        void AddEnrollment(Enrollment enrollment);

        void SaveChanges();

        void UpdateEnrollment(Enrollment enrollment);

        void DeleteEnrollment(int enrollmentId);

       

    }
}
