using System.ComponentModel.DataAnnotations;

namespace FlashCards.Desktop.Models.Identity
{
	public class RegisterDTO
	{
		[Required]
		[StringLength(20)]
		public string? PersonName { get; set; }

		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		[Phone]
		public string? PhoneNumber { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required]
		[Compare(nameof(Password))]
		public string? ConfirmPassword { get; set; }
	}
}
