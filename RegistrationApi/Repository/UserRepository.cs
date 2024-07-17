using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyAppDbContext _context;

        public UserRepository(MyAppDbContext _context)
        {
            this._context = _context;
        }

        public void AddUser(Userinfo userinfo)
        {
          return  
        }

        public Userinfo GetUserByUsernameAndPassword(string username, string password)
        {
          return   
        }

        public int GetusermaxId()
        {
          return   
        }

        public void SaveChanges()
        {
          return  
        }
    }
}
