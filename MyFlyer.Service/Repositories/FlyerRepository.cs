using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;

namespace MyFlyer.Service.Repositories
{
    public class FlyerRepository : Repository<Flyer>, IFlyerRepository
    {
        public FlyerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}