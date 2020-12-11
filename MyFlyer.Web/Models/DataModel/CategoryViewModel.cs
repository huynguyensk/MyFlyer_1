using System.Collections.Generic;
namespace MyFlyer.Web.Models.DataModel
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Flyer_CategoryId { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }

    }
}