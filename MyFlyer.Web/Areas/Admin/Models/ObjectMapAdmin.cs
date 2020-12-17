using AutoMapper;
using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.Areas.Admin.Models
{
    public class ObjectMapAdmin : Profile
    {
        public ObjectMapAdmin()
        {
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppRole, RoleViewModel>().ReverseMap();
            CreateMap<Merchant, MerchantViewModelAdmin>().ReverseMap();
        }
    }
}
