using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private readonly MyAppDbContext _myAppDbContext;

        public EnrollmentRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            enrollment.enrollmentId = NextEnrollmentId();
            _myAppDbContext.Enrollments.Add(enrollment);
        }

        public void DeleteEnrollment(int enrollmentId)
        {
          var enroll=  _myAppDbContext.Enrollments.Find(enrollmentId);
            if (enroll != null)
            {
                _myAppDbContext.Enrollments.Remove(enroll);
                _myAppDbContext.SaveChanges();
            }
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
          return  _myAppDbContext.Enrollments.ToList();
        }

        public Enrollment GetEnrollment(int id)
        {
            return _myAppDbContext.Enrollments.Find(id);  
        }

      

        public void SaveChanges()
        {
            _myAppDbContext.SaveChanges();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _myAppDbContext.Enrollments.Update(enrollment);
            _myAppDbContext.SaveChanges();
        }
        private int NextEnrollmentId()
        {
            var nextid = _myAppDbContext.Enrollments.Max(m => (int?)m.enrollmentId) ?? 0;
            return nextid + 1;
        }
    }
}
