using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Userinfo> GetAllUsers();
        Userinfo GetUserByUsernameAndPassword(string username, string email);
        int GetusermaxId();
        void AddUser(Userinfo userinfo);
        void SaveChanges();
    }
}
