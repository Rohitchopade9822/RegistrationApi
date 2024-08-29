using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NewAPIConsume.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
