using System;
using Newtonsoft.Json;
using System.Net;
using MyFlyer.Service.CrawlModel;

namespace MyFlyer.Service
{
    public class Function
    {
        [Obsolete]
        public static CrawlObject GetAllCrawlModels(string url)
        {
            using (var webClient = new WebClient())
            {
                var json = string.Empty; // attempt to download JSON data as a string 
                webClient.Headers.Add("Accept", "application/json");
                json = webClient.DownloadString(url);
                var crawlObjects = JsonConvert.DeserializeObject<CrawlObject>(json);
                return crawlObjects;
            }
        }
    }
}