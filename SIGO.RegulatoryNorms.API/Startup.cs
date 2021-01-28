using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIGO.RegulatoryNorms.Application.Services;
using SIGO.RegulatoryNorms.Application.Services.External;
using SIGO.RegulatoryNorms.Application.Services.Messaging;
using SIGO.RegulatoryNorms.Infrastructure.Persistence.Repositories;

namespace SIGO.RegulatoryNorms.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExternalRegulatoryNormsService, ExternalRegulatoryNormsService>();
            services.AddScoped<IExternalRegulatoryNormsClient, ExternalRegulatoryNormsClient>();
            services.AddScoped<IRegulatoryNormsService, RegulatoryNormsService>();
            services.AddScoped<IQueuePublisher, QueuePublisher>();
        }
    }
}
