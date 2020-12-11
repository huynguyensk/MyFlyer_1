using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFlyer.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryByMerchantId(int merchantId);
        Category AddCategory(Category entity);
    }
}
