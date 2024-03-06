using CoastlineBeauty.Database;
using CoastlineBeauty.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoastlineBeauty.Controllers
{
    public class ProductController : Controller
    {
        // Get implementation of AppDbContext. 
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        // Display Product List
        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (obj.Gender.ToLower() != "male" && obj.Gender.ToLower() != "female")
            {
                ModelState.AddModelError("Gender", "The Gender field can only be Male or Female");
            }
            if(obj.Size > 1000)
            {
                ModelState.AddModelError("Size", "The Size field cannot be larger than 1000");
            }
            if(obj.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "The Quantity field must be greater than 0");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? ProductId)
        {
            if(ProductId == null || ProductId == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _db.Products.Find(ProductId);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? ProductId)
        {
            if (ProductId == null || ProductId == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _db.Products.Find(ProductId);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? ProductId)
        {
            Product? obj = _db.Products.Find(ProductId);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
