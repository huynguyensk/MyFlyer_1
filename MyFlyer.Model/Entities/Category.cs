using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlyer.Model.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            MerchantCategories = new List<MerchantCategory>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }
        public List<Product> Products { get; set; }
        [NotMapped]
        public virtual List<Merchant> Merchants { get { return GetMerchants(); } }
        public List<MerchantCategory> MerchantCategories { get; set; }
        public List<Merchant> GetMerchants()
        {
            var result = new List<Merchant>();
            foreach (var merchantCategory in MerchantCategories)
            {
                result.Add(merchantCategory.Merchant);
            }
            return result;
        }
    }
}