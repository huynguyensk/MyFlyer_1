using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Web.Models.DataModel;

namespace MyFlyer.Web.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public MerchantController(IMerchantRepository merchantRepository, IProductRepository productRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // GET: Merchant/Details/5
        public ActionResult Details(int id)
        {
            var products = _productRepository.GetProductInMerchant(id);
            var allProdcut = _productRepository.GetAll();
            var x = allProdcut.Find(p => p.Category != null);
            var mapped = _mapper.Map<List<ProductViewModel>>(products);
            return View(mapped);
        }

        // GET: Merchant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Merchant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Merchant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Merchant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Merchant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Merchant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}