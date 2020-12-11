namespace MyFlyer.Service.CrawlModel
{
    public class SelectedStore
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string postal_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string phone_number { get; set; }
        public string merchant_store_code { get; set; }
        public object mon_open { get; set; }
        public object mon_close { get; set; }
        public object tue_open { get; set; }
        public object tue_close { get; set; }
        public object wed_open { get; set; }
        public object wed_close { get; set; }
        public object thu_open { get; set; }
        public object thu_close { get; set; }
        public object fri_open { get; set; }
        public object fri_close { get; set; }
        public object sat_open { get; set; }
        public object sat_close { get; set; }
        public object sun_open { get; set; }
        public object sun_close { get; set; }
    }
}