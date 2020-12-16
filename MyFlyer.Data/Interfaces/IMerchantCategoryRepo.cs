
using MyFlyer.Model.Entities;
using System.Collections.Generic;

namespace MyFlyer.Data.Interfaces
{
    public interface IMerchantCategoryRepo : IRepository<MerchantCategory>
    {
        List<int> GetCategoriesInMerchant(Merchant merchant);
    }
}