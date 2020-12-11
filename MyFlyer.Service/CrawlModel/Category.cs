namespace MyFlyer.Service.CrawlModel
{
    public class Category
    {
        public int id { get; set; }
        public int flyer_category_id { get; set; }
        public object run_category_id { get; set; }
        public object skipped { get; set; }
        public string name { get; set; }
        public double left { get; set; }
        public double bottom { get; set; }
        public double right { get; set; }
        public double top { get; set; }
        public string thumbnail_image_url { get; set; }
    }
}