using System.ComponentModel.DataAnnotations;

namespace FlashCards.Desktop.Models.Identity
{
	public class LoginDTO
	{
		[EmailAddress]
		[Required]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }	
	}
}
