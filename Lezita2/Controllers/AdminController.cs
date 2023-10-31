using Lezita2.Context;
using Lezita2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Lezita2.Models.ViewModels;

namespace Lezita2.Controllers
{
    public class AdminController : Controller
    {
        LezitaDbContext _context = new LezitaDbContext();
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(IWebHostEnvironment hostingEnvironment) 
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private void DeleteImage(string imagePath,string bg_imagePath)
        {
            // Eğer product.Image, tam bir yol değilse, uygulamanızın wwwroot klasörüyle birleştirin.(dosya "/" ile başlamamalı. )
            var photoPath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath);
            var bgPhotoPath = Path.Combine(_hostingEnvironment.WebRootPath, bg_imagePath);
            // Dosyanın var olup olmadığını kontrol edin ve silin
            if (System.IO.File.Exists(photoPath))
                System.IO.File.Delete(photoPath); 
            if (System.IO.File.Exists(bgPhotoPath))
                System.IO.File.Delete(bgPhotoPath);
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            if (products is null) return View();

            return View(products);
        }
        [HttpGet]
        public IActionResult AddProducts()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductCreateVM formProduct)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(formProduct);
            }
            Product product = new();
            //Nesneye değerler atandı.
            product.Name = formProduct.Name;
            product.Price = formProduct.Price;
            product.Quantity = formProduct.Quantity;
            product.Description = formProduct.Description;
            product.CategoryId = formProduct.CategoryId;
            formProduct.AddImageAsync(product);

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("GetProducts");
        }
        [HttpPost]
        public IActionResult DeleteProducts(int id)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == id);
            if (product is not null)
            {
                if(product.Image is not null)
                    DeleteImage(product.Image.TrimStart('/'),"");
                //Db silme işlemi
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("GetProducts");
        }
        [HttpGet]
        public IActionResult UpdateProducts(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var product = _context.Products.Find(id);
            ProductUpdateVM formProduct = new()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity=product.Quantity


            };
            TempData["OldProductImage"] = product.Image;
            return View(formProduct);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductsAsync(ProductUpdateVM formProduct)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(formProduct);
            }
            Product product = _context.Products.Find(formProduct.Id);
            product.Name = formProduct.Name;
            product.Price = formProduct.Price;
            product.Quantity = formProduct.Quantity;
            product.Description = formProduct.Description;
            product.CategoryId = formProduct.CategoryId;
            formProduct.AddImageAsync(product);
            DeleteImage(TempData["OldProductImage"].ToString().TrimStart('/'),"");
            _context.SaveChanges();
            return RedirectToAction("GetProducts");
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult AddCategories()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategories(CategoryCreateVM formCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(formCategory);
            }
            Category category = new();
            category.Name = formCategory.Name;
            formCategory.AddImageAsync(category);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("GetCategories");
        }
        [HttpPost]
        public IActionResult DeleteCategories(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is not null)
            {
                var products = _context.Products.Where(c => c.CategoryId == id).ToList();
                if (products.Any())
                {
                    foreach (var product in products)
                    {
                        DeleteImage(product.Image.TrimStart('/'),"");
                        _context.Products.Remove(product);
                    }
                }
                if (category.Image is not null)
                    DeleteImage(category.Image.TrimStart('/'),category.BackGroundImage.TrimStart('/'));
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

            return RedirectToAction("GetCategories");
        }
        [HttpGet]
        public IActionResult UpdateCategories(int id)
        {
            var category = _context.Categories.Find(id);
            CategoryUpdateVM addCategoryImage = new()
            {
                Id = category.Id,
                Name = category.Name,

            };
            TempData["OldCategoryImage"] = category.Image;
            TempData["OldCategoryBgImage"] = category.BackGroundImage;
            return View(addCategoryImage);
        }
        public async Task<IActionResult> UpdateCategoriesAsync(CategoryUpdateVM formCategory)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(formCategory);
            }
            Category category = _context.Categories.Find(formCategory.Id);
            category.Name = formCategory.Name;
            formCategory.AddImageAsync(category);
            DeleteImage(TempData["OldCategoryImage"].ToString().TrimStart('/'), TempData["OldCategoryBgImage"].ToString().TrimStart('/'));
            _context.SaveChanges();
            return RedirectToAction("GetCategories");
        }
    }
}
