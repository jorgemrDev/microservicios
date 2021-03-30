using Microsoft.Extensions.Logging;
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

        public BookHandler(ILogger<BookHandler> logger)
        {
            _logger = logger;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _logger.LogInformation("Process Starts");
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookModel>(content, options);
            }
            _logger.LogInformation($"This process tooks {time.ElapsedMilliseconds} ms");
            return response;
        }
    }
}
