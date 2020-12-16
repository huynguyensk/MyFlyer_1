using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using System.Collections.Generic;

namespace MyFlyer.Service.Repositories
{
    public class MerchantCategoryRepo : Repository<MerchantCategory>, IMerchantCategoryRepo
    {
        public MerchantCategoryRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<int> GetCategoriesInMerchant(Merchant merchant)
        {
            var result = new List<int>();
            var merchantCategories = GetAll();
            foreach(var item in merchantCategories)
            {
                if (item.MerchantId == merchant.Id)
                {
                    result.Add(item.CategoryId);
                }
            }
            return result;
        }
    }
}
