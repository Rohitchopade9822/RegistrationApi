using System.ComponentModel.DataAnnotations;

namespace NewAPIConsume.Models
{
	public class UserModel
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		public string? Role { get; set; }
		
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[StringLength(12)]
		public string? MobileNumber { get; set; }

		[StringLength(900)]
		public string ProfileImage { get; set; }
	}

}
