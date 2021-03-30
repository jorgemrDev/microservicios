using Microsoft.Extensions.Logging;
using StoreServices.Api.Gateway.Interfaces;
using StoreServices.Api.Gateway.RemoteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreServices.Api.Gateway.Implementations
{
    public class AuthorRemote : IAuthorRemote
    {

        public readonly IHttpClientFactory _httpClient;
        public readonly ILogger<AuthorRemote> _logger;

        public AuthorRemote(IHttpClientFactory httpClient,
            ILogger<AuthorRemote> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<(bool result, AuthorModelRemote author, string errorMessage)> GetAuthor(Guid AuthorId)
        {
            try
            {
                var client = _httpClient.CreateClient("AuthorService");
                var response = await client.GetAsync($"Author/{AuthorId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var author = JsonSerializer.Deserialize<AuthorModelRemote>(content, options);
                    return (true, author, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
