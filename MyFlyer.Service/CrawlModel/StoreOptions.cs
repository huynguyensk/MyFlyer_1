using System.Collections.Generic;
namespace MyFlyer.Service.CrawlModel
{
    public class StoreOptions
    {
        public bool is_store_select_flyer { get; set; }
        public bool merchant_has_store_select { get; set; }
        public string selected_store_name { get; set; }
        public string selected_store_address { get; set; }
        public SelectedStore selected_store { get; set; }
        public bool force_popup { get; set; }
        public IList<object> nearest_stores { get; set; }
        public object popup_reason { get; set; }
        public object default_store_code { get; set; }
    }
}