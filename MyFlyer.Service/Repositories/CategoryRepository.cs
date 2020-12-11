using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyFlyer.Service.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Category AddCategory(Category entity)
        {
            var cat = GetByCondition(c => c.Name == entity.Name).FirstOrDefault();
            if (cat == null)
            {
                Add(entity);
            }
            return cat;
        }

        public List<Category> GetCategoryByMerchantId(int merchantId)
        {
            var categories = GetAll();
            return categories;
        }
    }
}
