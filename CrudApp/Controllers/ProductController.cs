using CrudApp.Data;
using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Name, Price, Description, Stock, Active")] Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                TempData["Notification"] = "Product Created Successfully";
                TempData["NotificationType"] = "Success";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]

        public IActionResult Edit([Bind("Id, Name, Price, Description, Stock, Active")] Product produc)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(produc);
                _context.SaveChanges();
                TempData["Notification"] = "Product Edit Successfully";
                TempData["NotificationType"] = "Success";
                return RedirectToAction("Index");
            }
            return View(produc);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Delete Successfully";
                TempData["NotificationType"] = "Success";
            }
            return RedirectToAction("Index");
        }
    }
}
