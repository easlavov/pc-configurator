namespace PCConfigurator.Application.Repositories
{
    using System.Linq;

    using PCConfigurator.Core;

    public interface Repository<T> where T: Entity
    {
        T GetById(long id);

        IQueryable<T> GetAll();

        T Add(T entity);

        void Delete(long id);
    }
}
