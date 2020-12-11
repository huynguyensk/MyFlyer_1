using System.ComponentModel.DataAnnotations.Schema;
namespace MyFlyer.Web.Models.DataModel
{
    public class CartItemViewModel : BaseViewModel
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductViewModel ProductViewModel { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return ProductViewModel.CurrentPrice; } }
        public decimal TotalCartItem { get { return Quantity * UnitPrice; } }
        public virtual CartViewModel CartVIewModel { get; set; }
    }
}