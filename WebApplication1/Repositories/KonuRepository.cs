using WebApplication1.Data;
using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class KonuRepository : Repository<Konu>, IKonuRepository
    {
        public KonuRepository(Context db) : base(db)
        {
        }
    }
}
