using CakeCompany.IServices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace CakeCompany
{
    public class Worker : IHostedService
    {
        readonly IHostApplicationLifetime _hostLifetime;
        readonly IShipmentProvider _shipmentProvider;
        readonly ILogger<Worker> _logger;
        int? _exitCode;


        public Worker(ILogger<Worker> logger, IShipmentProvider shipmentProvider, IHostApplicationLifetime hostLifetime)
        {
            _hostLifetime = hostLifetime ?? throw new ArgumentNullException(nameof(hostLifetime));
            _shipmentProvider = shipmentProvider ?? throw new ArgumentNullException(nameof(shipmentProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Application is started");

            try
            {
                _shipmentProvider.GetShipment();
                _logger?.LogInformation("Application is Finished");
                _exitCode = 0;
            }
            catch (OperationCanceledException)
            {
                _logger?.LogInformation("The job has been killed with CTRL+C");
                _exitCode = -1;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "An error occurred");
                _exitCode = 1;
            }
            finally
            {
                _hostLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            _logger?.LogInformation($"Shutting down the service with code {Environment.ExitCode}");
            return Task.CompletedTask;
        }
    }
}