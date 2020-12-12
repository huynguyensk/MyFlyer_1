using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Service;
using MyFlyer.Web.Areas.Admin.Models;
using MyFlyer.Web.Models.DataModel;
using MyFlyer.Model.Entities;
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
        [Obsolete]
        public ActionResult Create(string url)
        {
            if (!ModelState.IsValid)
            {
                return View(url);
            }
            else
            {
                var flyerViewModel = new FlyerViewModel
                {
                    Url = url
                };

                if (!_flyerRepository.IsExist(f => f.Url == url))
                {
                    var crawlObject = Function.GetAllCrawlModels(url);
                    var merchant = new Merchant
                    {
                        Name = crawlObject.merchant,
                        Url = crawlObject.merchant_url,
                        LogoFile = crawlObject.merchant_logo
                    };
                    if (!_merchantRepository.IsExist(m => m.Name == merchant.Name))
                    {
                        _merchantRepository.Add(merchant);
                    }
                    else
                    {
                        merchant = _merchantRepository.GetByCondition(m => m.Name == merchant.Name).FirstOrDefault();
                    }

                    foreach (var item in crawlObject.items)
                    {
                        if (item.current_price != null)
                        {
                            var product = new Product
                            {
                                Name = item.name,
                                CurrentPrice = Convert.ToDecimal(item.current_price),
                                Brand = item.brand,
                                Description = item.description,
                                Discount_percent = item.discount_percent.ToString(),
                                DisplayName = item.display_name,
                                Dist_coupon_image_url = item.dist_coupon_image_url,
                                Image = item.large_image_url,
                                Url = item.url,
                                InStoreOnly = item.in_store_only,
                                X_large_image_url = item.x_large_image_url,
                                Sale_Story = item.sale_story,
                                Item_Id = item.flyer_item_id,
                                Valid_from = DateTime.Parse(item.valid_from),
                                Valid_to = DateTime.Parse(item.valid_to)
                            };

                            if (item.category_names.Count > 0)
                            {
                                string cateName = item.category_names[0];
                                var proCate = new Category();
                                if (_categoryReposity.IsExist(c => c.Name == cateName))
                                {
                                    proCate = _categoryReposity.GetByCondition(c => c.Name == cateName).FirstOrDefault();
                                }
                                else
                                {
                                    proCate.Name = cateName;
                                    _categoryReposity.Add(proCate);
                                    if (!merchant.Categories.Contains(proCate))
                                    {
                                        merchant.Categories.Add(proCate);
                                    }
                                }
                                product.Category = proCate;
                            }
                            if (!_productRepository.IsExist(p => p.Item_Id == product.Item_Id))
                            {
                                _productRepository.Add(product);
                                if (!merchant.Products.Contains(product))
                                {
                                    merchant.Products.Add(product);
                                }
                            }
                        }
                    }
                    _merchantRepository.Add(merchant);
                    var flyer = new Flyer
                    {
                        Url = url,
                        Valid_from = crawlObject.valid_from,
                        Valid_to = crawlObject.valid_to
                    };
                    _flyerRepository.Add(flyer);
                }
            }
            return View();
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