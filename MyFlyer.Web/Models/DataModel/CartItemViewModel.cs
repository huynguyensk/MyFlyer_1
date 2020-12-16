namespace MyFlyer.Web.Models.DataModel
{
    public class CartItemViewModel : BaseViewModel
    {
        public virtual ProductViewModel Product { get; set; }
        public virtual CartViewModel Cart { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.CurrentPrice; } }
        public decimal TotalCartItem { get { return Quantity * UnitPrice; } }
    }
}