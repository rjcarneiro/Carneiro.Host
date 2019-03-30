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

        protected GenericBackgroundSettings Settings { get; }

        protected GenericBackgroundService(IOptions<GenericBackgroundSettings> handlerSettings)
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

    public class GenericBackgroundSettings
    {
        public GenericBackgroundTimeoutSettings Timeout { get; set; } = new GenericBackgroundTimeoutSettings();

        public override string ToString() => Timeout.ToString();
    }

    public class GenericBackgroundTimeoutSettings
    {
        public int Min { get; set; } = 1;
        public int Max { get; set; } = 5;

        public override string ToString() => $"Min: {Min} seconds Max: {Max} seconds";
    }
}
