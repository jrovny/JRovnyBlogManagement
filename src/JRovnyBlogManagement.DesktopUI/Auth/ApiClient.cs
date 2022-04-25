using System.Net.Http;

namespace JRovnyBlogManagement.DesktopUI.Auth
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
