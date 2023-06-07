#nullable disable

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RCL.SSL.SDK;

IConfiguration configuration = null;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", true, true);
        builder.AddEnvironmentVariables();
        configuration = builder.Build();
    })
        .ConfigureServices(services =>
        {
            services.AddRCLSDKService(options => configuration.Bind("RCLSDK", options));
        })
    .Build();

host.Run();
