using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlyer.Model.Entities
{
    public class Merchant : BaseEntity
    {
        public Merchant()
        {
            Stores = new List<Store>();
            Products = new List<Product>();
            MerchantCategories = new List<MerchantCategory>();

        }
        public string Name { get; set; }
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; } = true;
        //-------------------------
        public List<Store> Stores { get; set; }
        public List<Product> Products { get; set; }
        [NotMapped]
        public List<Category> Categories { get { return GetCategories(); } }
        public List<MerchantCategory> MerchantCategories { get; set; }
        public List<Category> GetCategories()
        {
            var result = new List<Category>();
            foreach (var merchantCategory in MerchantCategories)
                result.Add(merchantCategory.Category);
            return result;
        }
    }
}