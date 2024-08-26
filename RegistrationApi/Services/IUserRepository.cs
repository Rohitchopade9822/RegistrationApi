using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUsernameAndPassword(string username, string email);
        int GetusermaxId();
        void AddUser(User user);
        void SaveChanges();
    }
}
