using FlashCards.Desktop.Models.Identity;
using System.Net.Http;

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

        } 
    }
}
