using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public interface IMaterialRepository
    {

        IEnumerable<Material> GetMaterials();
        void AddMaterial (Material material);
        void SaveChanges ();
        
        
    }
}
