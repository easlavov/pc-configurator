namespace PCConfigurator.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    using Microsoft.EntityFrameworkCore;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using PCConfigurator.Application;
    using PCConfigurator.Application.Components;
    using PCConfigurator.Application.Configurations;
    using PCConfigurator.Application.Repositories;

    using PCConfigurator.Core;

    using PCConfigurator.DataAccess.Mssql.EntityFramework;
    using PCConfigurator.DataAccess.Mssql.EntityFramework.Repositories;

    using PCConfigurator.Web.Extensions;    

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
                options
                    .UseSqlServer(Configuration.GetConnectionString(ConnectionStringName)));

            ConfigureApplicationServices(services);
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<EntityManager<ComponentType>>();
            services.AddScoped<Repository<ComponentType>, GenericMssqlRepository<ComponentType>>();

            services.AddScoped<ComponentsManager>();
            services.AddScoped<Repository<Component>, ComponentRepository>();

            services.AddScoped<ConfigurationsManager>();
            services.AddScoped<Repository<Configuration>, ConfigurationsRepository>();

            services.AddScoped<DbContext, PCConfiguratorDBContext>();
            services.UseOneTransactionPerHttpCall(System.Data.IsolationLevel.ReadCommitted);
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
                    pattern: "{controller=Configurations}/{action=Index}/{id?}");
            });
        }
    }
}
