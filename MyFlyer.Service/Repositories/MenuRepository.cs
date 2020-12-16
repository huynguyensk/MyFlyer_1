using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Service.Repositories;

namespace MyFlyer.Application.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
