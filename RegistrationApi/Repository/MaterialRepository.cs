
using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private MyAppDbContext _context;

        public MaterialRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetMaterials()
        {
            return _context.Materials.ToList();
        }

        public void AddMaterial(Material material)
        {
            material.materialId= GetNextMaterialId();
            _context.Materials.Add(material);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        private int GetNextMaterialId()
        {
            var maxMaterialId = _context.Materials.Max(m => (int?)m.materialId) ?? 0;
            return maxMaterialId + 1;
        }


    }
}