using System.Collections.Generic;
namespace MyFlyer.Web.Models.DataModel
{
    public class MerchantViewModel : BaseViewModel
    {
        public MerchantViewModel()
        {
            Products = new HashSet<ProductViewModel>();
            Categories = new HashSet<CategoryViewModel>();
        }
        public string Name { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
        public virtual ICollection<CategoryViewModel> Categories { get; set; }
    }
}