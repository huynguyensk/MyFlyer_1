using System;
using System.Collections.Generic;
namespace MyFlyer.Service.CrawlModel
{
    public class CrawlObject
    {
        public int id { get; set; }
        public IList<Category> categories { get; set; }
        public LegibilityHeights legibility_heights { get; set; }
        public int correction_notices_count { get; set; }
        public string flyer_locale { get; set; }
        public int flyer_run_id { get; set; }
        public double height { get; set; }
        public string name_identifier { get; set; }
        public string path { get; set; }
        public IList<string> image_hosts { get; set; }
        public string pdf_url { get; set; }
        public string primary_stack { get; set; }
        public IList<double> resolutions { get; set; }
        public Tags tags { get; set; }
        public int timezone { get; set; }
        public IList<string> theme { get; set; }
        public string title { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }
        public double width { get; set; }
        public IList<Item> items { get; set; }
        public IList<object> spotlights { get; set; }
        public IList<object> category_spotlights { get; set; }
        public string flyer_run_internal_name { get; set; }
        public string flyer_run_external_name { get; set; }
        public int height_mode_modifier { get; set; }
        public IList<Page> pages { get; set; }
        public string preview_only_text { get; set; }
        public int flyer_type_id { get; set; }
        public string flyer_type_name { get; set; }
        public bool display_validity_dates { get; set; }
        public bool display_discount_slider { get; set; }
        public bool grocery_list { get; set; }
        public bool search { get; set; }
        public object search_url { get; set; }
        public string store_locator_url { get; set; }
        public string url { get; set; }
        public object skyscraper_url { get; set; }
        public int skyscraper_height { get; set; }
        public bool item_detail_overlay { get; set; }
        public string custom_discount_slider_name { get; set; }
        public string custom_all_sales_name { get; set; }
        public string custom_see_it { get; set; }
        public object custom_find_in_store_text { get; set; }
        public bool category_highlights_enabled { get; set; }
        public bool coupon_highlights_enabled { get; set; }
        public bool subscribe_enabled { get; set; }
        public int subscribe_pop_type { get; set; }
        public object subscribe_pop_url { get; set; }
        public object subscribe_pop_height { get; set; }
        public object subscribe_pop_width { get; set; }
        public string merchant { get; set; }
        public object deep_share_url { get; set; }
        public int merchant_id { get; set; }
        public string merchant_url { get; set; }
        public string merchant_logo { get; set; }
        public bool multi_flyer_shopping_list { get; set; }
        public string large_merchant_logo { get; set; }
        public int ltc_integration_type { get; set; }
        public bool spotlight_highlights { get; set; }
        public bool grid_view { get; set; }
        public string large_thumbnail_image_url { get; set; }
        public string thumbnail_image_url { get; set; }
        public bool is_ciab { get; set; }
        public int facing_starts_at { get; set; }
        public IList<object> tears { get; set; }
        public bool view_data_pipes { get; set; }
        public string locale { get; set; }
        public LocationOptions location_options { get; set; }
        public string validity_date { get; set; }
        public bool premium { get; set; }
        public IList<object> tracking_urls { get; set; }
        public StoreOptions store_options { get; set; }
    }
}