using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Models.DataModel;
using MyFlyer.Web.Util;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MyFlyer.Web.Controllers
{
    public class ProductController : Controller
    {
        public const string CARTKEY = "cart";
        public const string WISHKEY = "wish";

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMerchantCategoryRepo _merchantCategoryRepo;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public ProductController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMerchantRepository merchantRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, IMerchantCategoryRepo merchantCategoryRepo, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _merchantRepository = merchantRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _merchantCategoryRepo = merchantCategoryRepo;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int? merchId, int? cateId, string search = null, int pageSize = 12, int pageNo = 1)
        {
            var merchants = new List<Merchant>();
            var categories = new List<Category>();
            var products = new List<Product>();
            if (search != null)
            {
                search = search.ToLower();
                merchants = _merchantRepository.GetAll();
                products = _productRepository.GetByCondition(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search));
            }
            else
            {
                if ((!merchId.HasValue && !cateId.HasValue))
                {
                    merchants = _merchantRepository.GetAll();
                    products = _productRepository.GetAll();
                }
                else if (merchId.HasValue && (!cateId.HasValue))
                {
                    var merchant = _merchantRepository.GetById(merchId.Value);
                    merchants.Add(merchant);
                    foreach (var item in _merchantCategoryRepo.GetCategoriesInMerchant(merchant))
                    {
                        var cate = _categoryRepository.GetById(item);
                        categories.Add(cate);//categories contain products
                    }
                    products = _productRepository.GetProductInMerchant(merchId.Value);
                }
                else if (merchId.HasValue && cateId.HasValue)
                {
                    var merchant = _merchantRepository.GetById(merchId.Value);
                    merchants.Add(merchant);
                    foreach (var item in _merchantCategoryRepo.GetCategoriesInMerchant(merchant))
                    {
                        var cate = _categoryRepository.GetById(item);
                        if (cate.Products != null)
                        {
                            categories.Add(cate); //all category doesn't contain any product
                        }
                    }
                    products = _productRepository.GetProductInCategory(cateId.Value);

                }
            }

            categories = categories.Where(c => c.Products != null).ToList();
            categories.OrderByDescending(c => c.Products.Count);
            var merchantsView = _mapper.Map<List<MerchantViewModel>>(merchants);
            var categoriesView = _mapper.Map<List<CategoryViewModel>>(categories);
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            var pages = PagingList<ProductViewModel>.Create(productsView, pageNo, pageSize);
            dynamic model = new ExpandoObject();
            model.Merchants = merchantsView;
            model.Categories = categoriesView;
            model.Products = productsView;
            model.PageList = pages;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var merchants = _merchantRepository.GetAll();
            var product = _productRepository.GetById(id);
            var productView = _mapper.Map<ProductViewModel>(product);
            var merchantsView = _mapper.Map<List<MerchantViewModel>>(merchants);
            dynamic model = new ExpandoObject();
            model.Product = productView;
            model.Merchants = merchantsView;
            return View(model);
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult AddToCart(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
                return NotFound("item not found");

            var cart = GetCartItems();
            var cartitem = cart.Where(c => c.ProductId == productId).FirstOrDefault();
            if (cartitem != null)
            {
                cartitem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Quantity = 1, ProductId = productId, Product = product, });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
            
        }
        public IActionResult AddToWishlist(int productId)
        {
            var user = System.Security.Claims.ClaimsPrincipal.Current;
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {               
                return RedirectToAction("Index");
            }
        }

        public IActionResult RemoveCart(int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        public IActionResult Cart()
        {
            var result = _mapper.Map<List<CartItemViewModel>>(GetCartItems());
            return View(result);
        }

        //------------------------------------------------
       

        public List<CartItem> GetCartItems()
        {
            var user = System.Security.Claims.ClaimsPrincipal.Current;            
            if (user == null)
            {
                var session = HttpContext.Session;
                string jsoncart = session.GetString(CARTKEY);
                if (jsoncart != null)
                {
                    return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
                }
                return new List<CartItem>();
            }
            else
            {
                return new List<CartItem>();
                //var cart = _cartRepository.GetByCondition(c => c.UserName == user.UserName).FirstOrDefault();
                //return cart.CartItems;
            }
        }
        public void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        public void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
    }
}