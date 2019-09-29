using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCConfigurator.DataAccess.Mssql.EntityFramework;
using Microsoft.EntityFrameworkCore;
using PCConfigurator.Application;
using PCConfigurator.Application.Repositories;
using PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories;

namespace PCConfigurator.Web
{
    public class Startup
    {
        private const string ConnectionStringName = @"PCConfiguratorConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.AddDbContext<PCConfiguratorDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringName)));

            ConfigureApplicationServices(services);
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ComponentTypesManager>();
            services.AddScoped<ComponentTypesRepository, MssqlComponentTypesRepository>();
            services.AddScoped<DbContext, PCConfiguratorDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}