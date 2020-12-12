using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFlyer.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryByMerchant(Merchant merchant);
        Category AddCategory(Category entity);
        
    }
}
