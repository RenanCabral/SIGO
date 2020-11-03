using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIGO.RegulatoryNorms.Infrastructure.CrossCutting;

namespace SIGO.RegulatoryNorms.API
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

            AppConfiguration.ConnectionString = Configuration.GetValue<string>("Database:ConnectionString:SIGO");
        }
    }
}
