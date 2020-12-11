namespace MyFlyer.Service.CrawlModel
{
    public class LocationOptions
    {
        public string postal_code { get; set; }
        public string name { get; set; }
        public bool confident { get; set; }
        public int location_source { get; set; }
        public object location_error { get; set; }
        public object requested_postal_code { get; set; }
        public string ip_address { get; set; }
        public string country { get; set; }
    }
}