using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlyer.Model.Entities
{
    public class MerchantCategory : BaseEntity
    {
        // public MerchantCategory(Merchant merchant, Category category)
        // {
        //     Merchant = merchant;
        //     Category = category;
        // }
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
