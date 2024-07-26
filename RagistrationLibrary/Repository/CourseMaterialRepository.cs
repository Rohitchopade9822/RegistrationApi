
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
        public async Task<IEnumerable<CourseMaterialViewModel>> GetCourseMaterials()
        {
            return await _myAppDbContext.Set<CourseMaterialViewModel>()
           .FromSqlRaw("_getCourse_Materails")
           .ToListAsync();
        }
    }
}
