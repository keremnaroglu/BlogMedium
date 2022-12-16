using System.Security.Principal;
using WebApplication1.Abstract;

namespace WebApplication1.IRepositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        T GetById(object id);

    }
}
