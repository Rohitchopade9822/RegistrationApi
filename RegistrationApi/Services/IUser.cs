using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IUser
    {

       
        IEnumerable<User> GetUsers();

        void AddUser(User user);

        void Savechanges();

        void UpdateUser(User user); 
        
        User GetUserbyid(int id);

        void DeleteUser(int id);
        
       

           
        
    }
}
