using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyFlyer.Web.Models.DataModel
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Discount_percent { get; set; }
        public string Image_ProDiscount { get; set; }
        public string Image_Product { get; set; }
        public string Url { get; set; }
        public bool InStoreOnly { get; set; }
        public string Pre_price_text { get; set; }
        public string Price_Text { get; set; }
        public DateTime Valid_to { get; set; }
        public DateTime Valid_from { get; set; }
        public string Large_image_url { get; set; }
        public string X_large_image_url { get; set; }
        public string Dist_coupon_image_url { get; set; }
        public string Sale_Story { get; set; }
        public long Item_Id { get; set; }

    }
}