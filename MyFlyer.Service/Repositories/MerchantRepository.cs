using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyFlyer.Service.Repositories
{
    public class MerchantRepository : Repository<Merchant>, IMerchantRepository
    {
        
        public MerchantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Merchant AddMerchant(Merchant entity)
        {
            var merch = GetByCondition(m => m.Name == entity.Name).FirstOrDefault();
            if (merch == null)
            {
                Add(entity);
            }
            return merch;
        }

    }
}
