using System.Collections.Generic;

namespace MyFlyer.Web.Models.DataModel
{
    public class CartViewModel : BaseViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItemViewModel>();
        }
        public string UserName { get; set; }
        public virtual List<CartItemViewModel> CartItems { get; set; }
    }
}