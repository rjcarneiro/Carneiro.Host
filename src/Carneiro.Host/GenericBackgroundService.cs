using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carneiro.Host
{
    public abstract class GenericBackgroundService : BackgroundService
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        protected GenericHandlerSettings Settings { get; }

        protected GenericBackgroundService(IOptions<GenericHandlerSettings> handlerSettings)
        {
            Settings = handlerSettings?.Value ?? throw new ArgumentNullException(nameof(handlerSettings));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await RunAsync(stoppingToken);

                await Task.Delay(_random.Next(Settings.Timeout.Min, Settings.Timeout.Max) * 1000, stoppingToken);

            } while (!stoppingToken.IsCancellationRequested);
        }

        protected abstract Task RunAsync(CancellationToken token);
    }

    public class GenericHandlerSettings
    {
        public GenericHandlerTimeoutSettings Timeout { get; set; }
    }

    public class GenericHandlerTimeoutSettings
    {
        public int Min { get; set; } = 1;
        public int Max { get; set; } = 5;
    }
}
