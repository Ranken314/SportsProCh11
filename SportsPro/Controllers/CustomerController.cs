using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            if (customer.CountryID == "XX")
            {
                ModelState.AddModelError(nameof(customer.CountryID), "Required.");
            }

            if (customer.CustomerID == 0 && TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(Context, customer.Email);

                if (!string.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
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
                if(customer.CustomerID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
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

