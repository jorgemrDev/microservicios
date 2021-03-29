using Microsoft.Extensions.Logging;
using StoreServices.Api.ShoppingCart.Interfaces;
using StoreServices.Api.ShoppingCart.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreServices.Api.ShoppingCart.Services
{
    public class BooksService : IBooksService
    {
        public readonly IHttpClientFactory _httpClient;
        public readonly ILogger<BooksService> _logger;

        public BooksService(IHttpClientFactory httpClient,
            ILogger<BooksService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, RemoteBook book, string errorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/Book/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var book = JsonSerializer.Deserialize<RemoteBook>(content, options);
                    return (true, book, null);
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
