using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext Context { get; set; }

        public ProductController(SportsProContext ctx) 
        { 
            Context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Product> products = Context.Products
                                     .OrderBy(p => p.ReleaseDate)
                                     .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = Context.Products.Find(id);
            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            string message;
            if(ModelState.IsValid)
            {
                if(product.ProductID == 0)
                {
                   Context.Products.Add(product);
                    message = product.ProductName + " was added.";
                }
                else
                {
                    Context.Products.Update(product);
                    message = product.ProductName + " was updated.";
                }
                Context.SaveChanges();
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            else
            {
                if(product.ProductID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            string message;

            Context.Products.Remove(product);
            message = product.ProductName + " was deleted.";
            TempData["message"] = message;
            Context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
