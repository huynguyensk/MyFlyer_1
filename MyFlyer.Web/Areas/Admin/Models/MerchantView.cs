using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.Areas.Admin.Models
{
    public class MerchantView
    {
        public string Name { get; set; }
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; }
    }
}
