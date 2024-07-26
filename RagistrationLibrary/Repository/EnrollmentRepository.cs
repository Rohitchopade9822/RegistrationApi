using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public class EnrollmentRepository
    {
        private readonly MyAppDbContext _myAppDbContext;

        public EnrollmentRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }



    }
}
