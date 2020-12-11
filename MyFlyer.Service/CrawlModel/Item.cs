using System.Collections.Generic;
namespace MyFlyer.Service.CrawlModel
{
    public class Item
    {
        public int flyer_item_id { get; set; }
        public int flyer_id { get; set; }
        public int flyer_type_id { get; set; }
        public int merchant_id { get; set; }
        public string brand { get; set; }
        public string display_name { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string current_price { get; set; }
        public string pre_price_text { get; set; }
        public string price_text { get; set; }
        public IList<object> category_ids { get; set; }
        public IList<string> category_names { get; set; }
        public IList<int> tag_ids { get; set; }
        public IList<object> sub_items_skus { get; set; }
        public double left { get; set; }
        public double bottom { get; set; }
        public double right { get; set; }
        public double top { get; set; }
        public object run_item_id { get; set; }
        public int? discount_percent { get; set; }
        public int display_type { get; set; }
        public object iframe_display_width { get; set; }
        public object iframe_display_height { get; set; }
        public string url { get; set; }
        public bool in_store_only { get; set; }
        public object review { get; set; }
        public bool video { get; set; }
        public object page_destination { get; set; }
        public bool video_count { get; set; }
        public object video_url { get; set; }
        public bool recipe { get; set; }
        public object recipe_title { get; set; }
        public IList<object> text_areas { get; set; }
        public IList<object> shopping_cart_urls { get; set; }
        public string large_image_url { get; set; }
        public string x_large_image_url { get; set; }
        public string dist_coupon_image_url { get; set; }
        public string sku { get; set; }
        public object custom1 { get; set; }
        public object custom2 { get; set; }
        public object custom3 { get; set; }
        public object custom4 { get; set; }
        public object custom5 { get; set; }
        public object custom6 { get; set; }
        public string valid_to { get; set; }
        public string valid_from { get; set; }
        public string disclaimer_text { get; set; }
        public string flyer_type_name_identifier { get; set; }
        public string flyer_type_name { get; set; }
        public int flyer_run_id { get; set; }
        public string sale_story { get; set; }
    }
}