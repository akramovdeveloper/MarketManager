using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace MarketManager.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
   
            _logger.LogInformation("Market Manager Request: {requestName} {request}",
                requestName,request);
        }
    }
}
