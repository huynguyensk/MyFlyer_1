using System.Collections.Generic;
namespace MyFlyer.Model.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        // public int Flyer_CategoryId { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }

    }
}