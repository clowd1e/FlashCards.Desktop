using FlashCards.Desktop.Models.Identity;

namespace FlashCards.Desktop.ServiceContracts
{
	public interface IUserService
	{
		Task Register(RegisterDTO? registerDTO);

		Task Login(LoginDTO? loginDTO);

		Task Logout();
	}
}
