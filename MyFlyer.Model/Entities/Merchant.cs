using System.Collections.Generic;
namespace MyFlyer.Model.Entities
{
    public class Merchant : BaseEntity
    {
        public Merchant()
        {
            Stores = new List<Store>();
            Products = new List<Product>();
            Categories = new List<Category>();
        }
        public string Name { get; set; }        
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; }
        //-------------------------
        public virtual List<Store> Stores { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}