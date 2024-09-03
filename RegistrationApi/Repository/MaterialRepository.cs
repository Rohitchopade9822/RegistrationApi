
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly MyAppDbContext _context;

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
            _context.SaveChanges();
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

        public Material GetMaterialById(int materialId)
        {

            return _context.Materials.Find(materialId);

        }

        public void UpdateMaterial(Material material)
        {
            _context.Materials.Update(material);
            _context.SaveChanges();
        }

        public void DeleteMaterial(int materialId)
        {
            var material = _context.Materials.Find(materialId);
            if(material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }

       
    }
}