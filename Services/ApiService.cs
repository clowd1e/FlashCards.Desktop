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

            var result = await _httpClient.PostAsJsonAsync(_connectionString + nameof(Register), registerDTO);

            result.EnsureSuccessStatusCode();
        } 

        public async Task Login(LoginDTO? loginDTO)
        {
            await ValidationHelper.ValidateObjects(loginDTO);

			var result = await _httpClient.PostAsJsonAsync(_connectionString + nameof(Login), loginDTO);

            result.EnsureSuccessStatusCode();
		}

        public async Task Logout()
        {
            var result = await _httpClient.GetAsync(_connectionString + nameof(Logout));

            result.EnsureSuccessStatusCode();
        }

        public async Task<AffectedResponse> SyncCards(List<Flashcard>? flashcards)
        {
            await ValidationHelper.ValidateObjects(flashcards);

            var responseMessage = await _httpClient.PostAsJsonAsync(_connectionString + nameof(SyncCards), flashcards);

            responseMessage.EnsureSuccessStatusCode();

            var affectedResponse = await responseMessage.Content.ReadFromJsonAsync<AffectedResponse>();

            if (affectedResponse is null)
            {
                throw new JsonSerializationException("Failed to deserialize response.");
            }

            return affectedResponse;
        }
    }
}
