using MyFlyer.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFlyer.Data.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetByUserName (string userName);
        List<Product> GetProductInCart(string userName);
        int TotalProductInCart(string userName);
        Cart GetExistingOrCreateNewCart(string userName);
    }
}
