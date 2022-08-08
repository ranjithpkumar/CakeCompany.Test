// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using CakeCompany;
using CakeCompany.ServiceRegistration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
.ConfigureLogging(logging =>
{
    logging.ClearProviders();
})
.UseSerilog((hostContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
})
.ConfigureAppConfiguration((hostContext, builder) =>
{
    builder.AddEnvironmentVariables();
})
.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<Worker>();
    services.AddServices();
    IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json", false)
    .Build();

    services.AddSingleton<IConfigurationRoot>(configuration);
});
