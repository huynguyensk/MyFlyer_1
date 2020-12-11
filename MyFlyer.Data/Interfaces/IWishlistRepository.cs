using MyFlyer.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFlyer.Data.Interfaces
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Wishlist GetByUserName(string userName);
        List<Product> GetProductInWishlist(string userName);
        int TotalProductInWishlist(string userName);
        void RemoveProductOutWishlist(int productId, string userName);
        void AddProductToWishlist(int productId, string userName);

    }
}
