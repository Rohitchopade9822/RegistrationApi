using RegistrationApi.DBModel;

namespace RegistrationApi.Services
{
    public interface IAuthenticationServices
    {
        string GenerateToken(User user);
        
       
    }
}
