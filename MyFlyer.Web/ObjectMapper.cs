using AutoMapper;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Models.DataModel;

namespace MyFlyer.Application
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Merchant, MerchantViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Wishlist, WishlistViewModel>().ReverseMap();
            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
        }
    }
}

