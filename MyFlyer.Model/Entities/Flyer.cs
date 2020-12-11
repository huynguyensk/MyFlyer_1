using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyFlyer.Model.Entities
{
    public class Flyer: BaseEntity
    {
        [UrlAttribute]
        public string Url { get; set; }
        public DateTime Valid_from { get; set; }
        public DateTime Valid_to { get; set; }
    }
}
