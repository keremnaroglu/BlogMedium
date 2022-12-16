using WebApplication1.Data;
using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class KisiRepository : Repository<Kisi>, IKisiRepository
    {
        public KisiRepository(Context db) : base(db)
        {
        }
    }
}
