using Microsoft.Extensions.Logging;
using StoreServices.Api.Gateway.Interfaces;
using StoreServices.Api.Gateway.RemoteBook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StoreServices.Api.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {

        private readonly ILogger<BookHandler> _logger;
        private readonly IAuthorRemote _authorRemote;

        public BookHandler(ILogger<BookHandler> logger,
            IAuthorRemote authorRemote)
        {
            _logger = logger;
            _authorRemote = authorRemote;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _logger.LogInformation("Process Starts");
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookModel>(content, options);
                var responseAuthor = await _authorRemote.GetAuthor(result.Author ?? Guid.Empty);
                if (responseAuthor.result)
                {
                    var author = responseAuthor.author;
                    result.AuthorData = author;
                    var stringResult = JsonSerializer.Serialize(result);
                    response.Content = new StringContent(stringResult, System.Text.Encoding.UTF8, "application/json");
                }
            }
            _logger.LogInformation($"This process tooks {time.ElapsedMilliseconds} ms");
            return response;
        }
    }
}
