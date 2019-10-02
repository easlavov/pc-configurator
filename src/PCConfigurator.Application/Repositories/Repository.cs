namespace PCConfigurator.Application.Repositories
{
    using System.Linq;

    using PCConfigurator.Core;

    public interface Repository<T> where T: Entity
    {
        T GetById(long id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllById(params long[] ids);

        T Add(T entity);

        T Update(T entity);

        void Delete(long id);
    }
}
