using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carneiro.Host
{
    public abstract class GenericHandler : BackgroundService
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        protected GenericHandlerSettings Settings { get; }

        protected GenericHandler(IOptions<GenericHandlerSettings> handlerSettings)
        {
            Settings = handlerSettings.Value;
        }

        protected async Task ExecuteAsync(CancellationToken token, Func<Task> task)
        {
            do
            {
                await task();

                await Task.Delay(_random.Next(Settings.Timeout.Min, Settings.Timeout.Max) * 1000, token);

            } while (!token.IsCancellationRequested);
        }
    }

    public class GenericHandlerSettings
    {
        public GenericHandlerTimeoutSettings Timeout { get; set; }
    }

    public class GenericHandlerTimeoutSettings
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
