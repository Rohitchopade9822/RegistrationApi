using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Repository
{
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        private readonly MyAppDbContext _myAppDbContext;

        public CourseMaterialRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }
        public async Task<IEnumerable<CourseMaterialViewModel>> GetCourseMaterials(int courseId)
        {
            var Coursematerial= await _myAppDbContext.Set<CourseMaterialViewModel>()
           .FromSqlRaw("EXEC new_CourseMaterial @courseId = {0}", courseId)
           .ToListAsync();
            return Coursematerial;
        }

        
    }
}
