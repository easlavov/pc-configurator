namespace PCConfigurator.Web.Extensions
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly IDbContextTransaction transaction;

        public UnitOfWorkFilter(IDbContextTransaction transaction)
        {
            this.transaction = transaction;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executedContext = await next.Invoke();
            if (executedContext.Exception == null)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
    }
}
