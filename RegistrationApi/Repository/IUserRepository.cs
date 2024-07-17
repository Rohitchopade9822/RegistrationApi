using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public interface IUserRepository
    {
        Userinfo GetUserByUsernameAndPassword(string username, string password);
        void AddUser(Userinfo userinfo);
        int GetusermaxId();
        void SaveChanges();
    }
}
