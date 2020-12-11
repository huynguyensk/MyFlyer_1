using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFlyer.Service.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Product GetProductById(int productId)
        {
            return GetById(productId);
        }
        public List<Product> GetProductByName(string productName)
        {
            return GetByCondition(p => p.Name == productName).ToList();
        }
        public List<Product> GetProductInCategory(int categoryId)
        {
            return GetByCondition(p => p.Category.Id == categoryId).ToList();
        }
        public List<Product> GetProductInMerchant(int merchantId)
        {
            return GetByCondition(p => p.Merchant.Id == merchantId).ToList();
        }
        public List<Product> GetProductList()
        {
            return GetAll();
        }
    }
}
