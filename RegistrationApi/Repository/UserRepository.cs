using Microsoft.EntityFrameworkCore;
using RegistrationApi.DBModel;

namespace RegistrationApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyAppDbContext _context;

        public UserRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public void AddUser(Userinfo userinfo)
        {
           _context.Userinfos.Add(userinfo);
        }

        public IEnumerable<Userinfo> GetAllUsers()
        {
            return _context.Userinfos.ToList();
        }

        public Userinfo GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Userinfos.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public int GetusermaxId()
        {
            return _context.Userinfos.Max(u => (int?)u.UserId) ?? 0;
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }
    }
}
