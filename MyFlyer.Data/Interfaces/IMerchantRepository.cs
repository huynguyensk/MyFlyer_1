using MyFlyer.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFlyer.Data.Interfaces
{
    public interface IMerchantRepository : IRepository<Merchant>
    {
        Merchant AddMerchant(Merchant entity);
        
       
    }
}
