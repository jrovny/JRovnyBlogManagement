using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI.Auth
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<T> GetAsync<T>(Uri location, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var response = await _client.SendAsync(
                new HttpRequestMessage(HttpMethod.Get, location.ToString()),
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken);
            response.EnsureSuccessStatusCode();

            using var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jsonSerializer = new JsonSerializer();

            return jsonSerializer.Deserialize<T>(jsonTextReader);
        }
    }
}
