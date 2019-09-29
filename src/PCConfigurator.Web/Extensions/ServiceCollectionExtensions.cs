using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace PCConfigurator.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void UseOneTransactionPerHttpCall(
            this IServiceCollection serviceCollection, 
            IsolationLevel level = IsolationLevel.ReadUncommitted)
        {
            serviceCollection.AddScoped<IDbContextTransaction>((serviceProvider) =>
            {
                var context = serviceProvider
                    .GetService<DbContext>();

                return context.Database.BeginTransaction(level);
            });

            serviceCollection.AddScoped(typeof(UnitOfWorkFilter), typeof(UnitOfWorkFilter));

            serviceCollection
                .AddMvc(setup =>
                {
                    setup.Filters.AddService<UnitOfWorkFilter>(1);
                });
        }
    }
}
