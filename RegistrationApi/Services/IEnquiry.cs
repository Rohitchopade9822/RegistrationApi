using Microsoft.EntityFrameworkCore.Diagnostics;
using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IEnquiry
    {
        IEnumerable<Enquiry> GetAllEnquiry();

        void AddEnquiry(Enquiry enquiry);

        void SaveChanges();

        Enquiry GetEnquiryById(int id);

        void UpdateEnquiry(Enquiry enquiry);

        void DeleteEnquiry(int enrollmentId);



    }
}
