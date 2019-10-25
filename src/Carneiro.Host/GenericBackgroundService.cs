using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carneiro.Host
{
    /// <summary>
    /// Generic Background Service
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.BackgroundService" />
    public abstract class GenericBackgroundService : BackgroundService
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        protected GenericBackgroundSettings Settings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericBackgroundService"/> class.
        /// </summary>
        /// <param name="handlerSettings">The handler settings.</param>
        /// <exception cref="ArgumentNullException">handlerSettings</exception>
        protected GenericBackgroundService(IOptions<GenericBackgroundSettings> handlerSettings)
        {
            Settings = handlerSettings?.Value ?? throw new ArgumentNullException(nameof(handlerSettings));
        }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await RunAsync(stoppingToken);

                await Task.Delay(_random.Next(Settings.Timeout.Min, Settings.Timeout.Max) * 1000, stoppingToken);

            } while (!stoppingToken.IsCancellationRequested);
        }

        /// <summary>
        /// Runs the task asynchronously.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        protected abstract Task RunAsync(CancellationToken token);
    }
}