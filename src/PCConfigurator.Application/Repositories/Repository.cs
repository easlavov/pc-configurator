namespace PCConfigurator.Application.Repositories
{
    using System.Linq;

    using PCConfigurator.Core;

    public interface Repository<T> where T: Entity
    {
        IQueryable<T> GetAll();

        void Delete(long id);
    }
}
