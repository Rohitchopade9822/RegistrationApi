using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;
using RegistrationApi.Services;

namespace RegistrationApi.Repository
{
    public class UserRepository:IUser
    {
        private readonly MyAppDbContext _myAppDbContext;

        public UserRepository(MyAppDbContext myAppDbContext)
        {
            _myAppDbContext = myAppDbContext;
        }

        public void AddUser(User user)
        {
            user.UserId = GetNextuserId();
            _myAppDbContext.Users.Add(user);
            _myAppDbContext.SaveChanges();
        }

       
        public void DeleteUser(int UserId)
        {
            var users = _myAppDbContext.Users.Find(UserId);
        }

        public User GetUserbyid(int id)
        {
            return _myAppDbContext.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _myAppDbContext.Users.ToList();
        }
       

        public void Savechanges()
        {
            _myAppDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _myAppDbContext.Update(user);
            _myAppDbContext.SaveChanges();

        }

        

        private int GetNextuserId()
        {
            var maxuserId = _myAppDbContext.Users.Max(m => (int?)m.UserId) ?? 0;
            return maxuserId + 1;
        }

       

       
    }
}
