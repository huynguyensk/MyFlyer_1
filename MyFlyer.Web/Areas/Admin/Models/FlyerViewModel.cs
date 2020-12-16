using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.Areas.Admin.Models
{
    public class FlyerViewModel
    {
        [Required]
        public string Url { get; set; }
        [Display(Name = "Valid From")]
        [DataType(DataType.Date)]
        public DateTime Valid_from { get; set; }
        [Display(Name = "Valid To")]
        [DataType(DataType.Date)]
        public DateTime Valid_to { get; set; }

    }
}
