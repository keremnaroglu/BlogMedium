using WebApplication1.Data;
using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MakaleRepository : Repository<Makale>, IMakaleRepository
    {
        public MakaleRepository(Context db) : base(db)
        {
        }
    }
}
