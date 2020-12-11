using System.Collections.Generic;
namespace MyFlyer.Model.Entities
{
    public class Merchant : BaseEntity
    {
        public Merchant()
        {
            Stores = new HashSet<Store>();
            Products = new HashSet<Product>();
            Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LogoFile { get; set; }
        public string Website { get; set; }
        public bool ShowInHome { get; set; }
        //-------------------------
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}