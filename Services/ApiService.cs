using FlashCards.Desktop.Helpers;
using FlashCards.Desktop.Models;
using FlashCards.Desktop.Models.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace FlashCards.Desktop.Services
{
	public class ApiService
	{
		private readonly HttpClient _httpClient;
        private readonly string _connectionString;

        public ApiService(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty");
            }

            _httpClient = new HttpClient();
            _connectionString = connectionString;
        }

        public async Task Register(RegisterDTO? registerDTO)
        {
            await ValidationHelper.ValidateObjects(registerDTO);

            await _httpClient.PostAsJsonAsync(_connectionString + nameof(Register), registerDTO);
        } 

        public async Task Login(LoginDTO? loginDTO)
        {
            await ValidationHelper.ValidateObjects(loginDTO);

			await _httpClient.PostAsJsonAsync(_connectionString + nameof(Login), loginDTO);
		}

        public async Task Logout()
        {
            await _httpClient.GetAsync(_connectionString + nameof(Logout));
        }

        public async Task<AffectedResponse> SyncCards(List<Flashcard>? flashcards)
        {
            await ValidationHelper.ValidateObjects(flashcards);

            var responseMessage = await _httpClient.PostAsJsonAsync(_connectionString + nameof(SyncCards), flashcards);

            var affectedResponse = await responseMessage.Content.ReadFromJsonAsync<AffectedResponse>();

            if (affectedResponse is null)
            {
                throw new JsonSerializationException("Failed to deserialize response.");
            }

            return affectedResponse;
        }
    }
}
