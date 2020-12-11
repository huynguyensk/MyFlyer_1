namespace MyFlyer.Service.CrawlModel
{
    public class Page
    {
        public int id { get; set; }
        public double left { get; set; }
        public double bottom { get; set; }
        public double right { get; set; }
        public double top { get; set; }
        public string name { get; set; }
        public int page { get; set; }
    }
}