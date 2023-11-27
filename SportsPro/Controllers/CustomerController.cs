using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext Context {  get; set; } 
        public CustomerController(SportsProContext ctx) 
        {
            Context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Customer> customers = Context.Customers
                                              .OrderBy(c => c.LastName)
                                              .ToList();

            return View(customers);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = Context.Countries.ToList();
            return View("AddEdit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Countries = Context.Countries.ToList();

            var customer = Context.Customers.Find(id);

            return View("AddEdit", customer);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if(customer.CustomerID == 0)
            {
                ViewBag.Action = "Add";
            }
            else
            {
                ViewBag.Action = "Edit";
            }

            if (ModelState.IsValid)
            {
                if (ViewBag.Action == "Add")
                {
                    Context.Customers.Add(customer);
                }
                else
                {
                    Context.Customers.Update(customer);
                }

                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Countries = Context.Countries.ToList();
                return View("AddEdit", customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = Context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

