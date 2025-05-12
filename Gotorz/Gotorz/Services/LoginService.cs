using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Gotorz.Models;


namespace Gotorz.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserLogin> AttemptLoginAsync(string email, string password)
        {
            string url = "https://localhost:5001/api/Auth/Login";
            var userLogin = new UserLogin
            {
                Username = email,
                Password = password
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, userLogin);

                if (response.IsSuccessStatusCode)
                {
                    // Handle successful login
                    var result = await response.Content.ReadFromJsonAsync<UserLogin>();
                    //await 
                    return result;
                }
                else
                {
                    // Handle failed login
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    // Show error message to the user
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
