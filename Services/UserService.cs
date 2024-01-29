using FlashCards.Desktop.Helpers;
using FlashCards.Desktop.Models.Identity;
using FlashCards.Desktop.Repositories;
using FlashCards.Desktop.ServiceContracts;

namespace FlashCards.Desktop.Services
{
	public class UserService : IUserService
	{
        private readonly ApiRepository _apiRepository;
		private bool _loggedIn = false;

        public UserService(ApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

		public async Task Login(LoginDTO? loginDTO)
		{
			await ValidationHelper.ValidateObjects(loginDTO);

			if (_loggedIn)
			{
				throw new InvalidOperationException("Unalbe to log in. User is already logged in.");
			}

			var response = await _apiRepository.Login(loginDTO!);
			response.EnsureSuccessStatusCode();
		}

		public async Task Logout()
		{
			if (!_loggedIn)
			{
				throw new InvalidOperationException("Unable to logout. User is not logged in.");
			}

			var response = await _apiRepository.Logout();
			response.EnsureSuccessStatusCode();
		}

		public async Task Register(RegisterDTO? registerDTO)
		{ 
			await ValidationHelper.ValidateObjects(registerDTO);

			if (_loggedIn)
			{
				throw new InvalidOperationException("Unable to register. User is already logged in.");
			}

			var response = await _apiRepository.Register(registerDTO!);

			response.EnsureSuccessStatusCode();
		}
	}
}
