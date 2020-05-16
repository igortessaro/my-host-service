using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using my_host_service.application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace my_host_service.application.Jobs
{
    public sealed class FirstJob : BackgroundService
    {
        private readonly ILogger<FirstJob> logger;
        private readonly ICustomerService customerService;

        public FirstJob(ILogger<FirstJob> logger, ICustomerService customerService)
        {
            this.logger = logger;
            this.customerService = customerService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Starting my first job.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Stoping my first job.");
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation("My first job has been executed.");

            var customer = this.customerService.FindByFirstName("Fulano");

            this.logger.LogInformation("Customer finded {Customer}", Newtonsoft.Json.JsonConvert.SerializeObject(customer));

            return Task.CompletedTask;
        }
    }
}
