using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class LoginViewModel
    {
        
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
