using AtualizarEstoqueAutomatico.Invocavel;
using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtualizarEstoqueAutomatico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScheduler();
            services.AddQueue();
            services.AddTransient<AtualizarEstoque>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var provider = app.ApplicationServices;
            provider.UseScheduler(scheduler =>
            {
                scheduler
                    .Schedule<AtualizarEstoque>()
                    .Daily();
                    //.Zoned(TimeZoneInfo.FindSystemTimeZoneById("America/Fortaleza"));
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
