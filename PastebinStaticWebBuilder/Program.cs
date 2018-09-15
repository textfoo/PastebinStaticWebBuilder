using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDBService.Interfaces;
using MongoDBService.Services;
using PastebinStaticWebBuilder.Config;
using PastebinStaticWebBuilder.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PastebinStaticWebBuilder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            await provider.GetService<App>().Run();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            services.AddLogging();

            var configuration = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetCurrentDirectory()}/Config/")
                .AddJsonFile("app-settings.json", false)
                .Build();
            services.AddOptions();

            services.Configure<MongoDBService.Config.MongoDBSettings>(configuration.GetSection("MongoDBSettings"));
            services.Configure<HtmlBuilderSettings>(configuration.GetSection("HtmlBuilderSettings"));

            services.AddSingleton<IMongoDBService, MongoDBService.Services.MongoDBService>();
            services.AddScoped<IPatebinHtmlBuilderService, PastebinHtmlBuilderService>();

            services.AddTransient<App>();
        }
    }
}
