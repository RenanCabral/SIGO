using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIGO.Infrastructure.CrossCutting;

namespace SIGO.IndustrialProcess.API
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(LoadConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void LoadConfiguration(HostBuilderContext ctx, IConfigurationBuilder config)
        {
            var env = ctx.HostingEnvironment;

            config
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ env.EnvironmentName }.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = config.Build();

            AppConfiguration.RabbitMqConfiguration = new RabbitMqConfiguration()
            {
                HostName = Configuration.GetValue<string>("RabbitMq:HostName"),
                UserName = Configuration.GetValue<string>("RabbitMq:UserName"),
                Password = Configuration.GetValue<string>("RabbitMq:Password"),
                VirtualHost = Configuration.GetValue<string>("RabbitMq:VirtualHost"),
                Port = Configuration.GetValue<int>("RabbitMq:Port")
            };
        }
    }
}
