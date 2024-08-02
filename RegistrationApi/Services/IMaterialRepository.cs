using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IMaterialRepository
    {

        IEnumerable<Material> GetMaterials();

        void AddMaterial(Material material);

        void SaveChanges();

        void UpdateMaterial(Material material);

        Material GetMaterialById(int id);

        void DeleteMaterial(int materialId);                                                                            



    }
}
