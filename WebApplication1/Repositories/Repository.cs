using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstract;
using WebApplication1.Data;
using WebApplication1.IRepositories;

namespace WebApplication1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private static Context _db;
        private static DbSet<T> _dbSet;

        public Repository(Context db)
        {
            if (_db == null)
            {
                _db = new Context();
            }
            _dbSet = _db.Set<T>();
        }

        public void Create(T entity)
        {
            if (!_dbSet.Contains(entity))
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Veri Silinemedi");
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {  
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Veri güncellenemedi");
            }

        }
    }
}
