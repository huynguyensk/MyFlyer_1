using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFlyer.Application.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
