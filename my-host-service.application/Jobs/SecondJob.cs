using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using my_host_service.application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace my_host_service.application.Jobs
{
    public sealed class SecondJob : BackgroundService
    {
        private readonly ILogger<SecondJob> logger;
        private readonly ICustomerService customerService;

        public SecondJob(ILogger<SecondJob> logger, ICustomerService customerService)
        {
            this.logger = logger;
            this.customerService = customerService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Starting my second job.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Stoping my second job.");
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation("My second job has been executed.");

            var customers = this.customerService.FindAllCustomers();

            this.logger.LogInformation("All customers finded {Customer}", Newtonsoft.Json.JsonConvert.SerializeObject(customers));

            return Task.CompletedTask;
        }
    }
}
