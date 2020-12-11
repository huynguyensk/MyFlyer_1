using Microsoft.AspNetCore.Identity;
namespace MyFlyer.Model.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Password { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        public virtual Cart Cart { get; set; }
    }
}