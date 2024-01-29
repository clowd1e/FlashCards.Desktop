using FlashCards.Desktop.Helpers;
using FlashCards.Desktop.Models;
using FlashCards.Desktop.Models.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace FlashCards.Desktop.Repositories
{
	public class ApiRepository
	{
		private readonly HttpClient _httpClient;
		private readonly string _connectionString;

		public ApiRepository(string? connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentException("Connection string cannot be null or empty");
			}

			_httpClient = new HttpClient();
			_connectionString = connectionString;
		}

		public async Task<HttpResponseMessage> Register(RegisterDTO registerDTO)
		{
			var result = await _httpClient.PostAsJsonAsync(_connectionString + nameof(Register), registerDTO);

			return result;
		}

		public async Task<HttpResponseMessage> Login(LoginDTO loginDTO)
		{
			var result = await _httpClient.PostAsJsonAsync(_connectionString + nameof(Login), loginDTO);

			return result;
		}

		public async Task<HttpResponseMessage> Logout()
		{
			var result = await _httpClient.GetAsync(_connectionString + nameof(Logout));

			return result;
		}

		public async Task<List<Flashcard>?> GetAllCards()
		{
			var result = await _httpClient.GetAsync(_connectionString + nameof(GetAllCards));

			result.EnsureSuccessStatusCode();

			var cards = await result.Content.ReadFromJsonAsync<List<Flashcard>>();

			return cards;
		}

		public async Task<AffectedResponse?> SyncCards(List<Flashcard> flashcards)
		{
			var responseMessage = await _httpClient.PostAsJsonAsync(_connectionString + nameof(SyncCards), flashcards);

			responseMessage.EnsureSuccessStatusCode();

			var affectedResponse = await responseMessage.Content.ReadFromJsonAsync<AffectedResponse>();

			return affectedResponse;
		}
	}
}
