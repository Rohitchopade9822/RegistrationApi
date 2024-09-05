using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class User
    {
            [Key]
            public int UserId { get; set; }

            
            [StringLength(90)]
            public string Username { get; set; }

        
            [StringLength(90)]
            public string Password { get; set; } 

            
            [StringLength(90)]
            public string Role { get; set; }

            
            [EmailAddress]
            public string? Email { get; set; }

            [StringLength(12)]
            public string? MobileNumber { get; set; }

            [StringLength(900)]
            public string ProfileImage { get; set; }
        
    }
}

