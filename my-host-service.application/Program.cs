using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using my_host_service.application.Jobs;
using my_host_service.application.Services;
using System.Threading.Tasks;

namespace my_host_service.application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost builder = new HostBuilder()
                .ConfigureLogging((hostContext, loggingBuilder) =>
                {
                    loggingBuilder
                        .AddConsole()
                        .AddDebug()
                        .AddEventLog();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ICustomerService, CustomerService>();
                    services.AddHostedService<FirstJob>();
                    services.AddHostedService<SecondJob>();
                })
                .Build();

            await builder.StartAsync();
            await builder.StopAsync();
        }
    }
}
