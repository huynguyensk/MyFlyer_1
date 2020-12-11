using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Web.Areas.Admin.Models;

namespace MyFlyer.Web.Areas.Admin.Controllers.FlyerManager
{
    [Area("admin")]
    public class FlyerController : Controller
    {
        private readonly IFlyerRepository _flyerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryReposity;
        private readonly IMerchantRepository _merchantRepository;

        public FlyerController(IFlyerRepository flyerRepository, IProductRepository productRepository, ICategoryRepository categoryReposity, IMerchantRepository merchantRepository)
        {
            _flyerRepository = flyerRepository;
            _productRepository = productRepository;
            _categoryReposity = categoryReposity;
            _merchantRepository = merchantRepository;
        }

        // GET: Flyer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Flyer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flyer/Create
        [HttpPost]
        public ActionResult Create(FlyerViewModel flyerViewModel)
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

        // GET: Flyer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flyer/Edit/5
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

        // GET: Flyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flyer/Delete/5
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