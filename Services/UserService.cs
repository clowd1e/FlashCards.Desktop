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
				throw new InvalidOperationException("Already logged in.");
			}

			await _apiRepository.Login(loginDTO);
		}

		public async Task Logout()
		{
			throw new NotImplementedException();
		}

		public async Task Register(RegisterDTO? registerDTO)
		{
			throw new NotImplementedException();
		}
	}
}
