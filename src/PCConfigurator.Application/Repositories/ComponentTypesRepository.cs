namespace PCConfigurator.Application.Repositories
{
    using System.Linq;

    using PCConfigurator.Core;

    public interface ComponentTypesRepository
    {
        IQueryable<ComponentType> GetAll();

        void Delete(long id);
    }
}
