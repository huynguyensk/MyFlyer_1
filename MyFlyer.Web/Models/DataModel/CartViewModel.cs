using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlyer.Web.Models.DataModel
{
    public class CartViewModel : BaseViewModel
    {

        public string UserName { get; set; }
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
        public decimal CartTotal { get { return CartItems.Sum(s => s.Quantity * s.UnitPrice); } }

    }
}