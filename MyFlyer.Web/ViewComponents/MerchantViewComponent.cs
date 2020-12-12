using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Web.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.ViewComponents
{
    public class MerchantViewComponent: ViewComponent
    {
        public readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public MerchantViewComponent(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var merchants = _merchantRepository.GetAll();
            var mapped = _mapper.Map<List<MerchantViewModel>>(merchants);
            return View(mapped);
        }
    }
}
