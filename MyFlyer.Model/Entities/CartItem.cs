using System.ComponentModel.DataAnnotations.Schema;
namespace MyFlyer.Model.Entities
{
    public class CartItem : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.CurrentPrice; } }
        public decimal TotalCartItem { get {return  Quantity * UnitPrice; } }
        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}