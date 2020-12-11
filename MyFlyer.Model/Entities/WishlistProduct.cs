using System.ComponentModel.DataAnnotations.Schema;
namespace MyFlyer.Model.Entities
{
    public class WishlistProduct : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Wishlist")]
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

    }
}