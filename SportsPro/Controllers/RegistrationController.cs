using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private SportsProUnit Data { get; set; }

        public RegistrationController(SportsProContext ctx)
        {
            Data = new SportsProUnit(ctx);
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            ViewBag.Customers = Data.Customers.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            });

            int custID = HttpContext.Session.GetInt32("custID") ?? 0;
            Customer customer;
            if (custID == 0)
            {
                customer = new Customer();
            }
            else
            {
                customer = Data.Customers.Get(custID);
            }

            return View(customer);
        }

        [HttpPost]
        [Route("[controller]s")]
        public IActionResult List(Customer customer)
        {
            HttpContext.Session.SetInt32("custID", customer.CustomerID);

            if (customer.CustomerID == 0)
            {
                TempData["message"] = "You must select a customer.";
                return RedirectToAction("GetCustomer");
            }
            else
            {
                return RedirectToAction("List", new { id = customer.CustomerID });
            }
        }

        [HttpGet]
        [Route("[controller]s")]
        public IActionResult List(int id)
        {
            RegistrationViewModel model = new RegistrationViewModel
            {
                CustomerID = id,
                Customer = Data.Customers.Get(id),
                Products = Data.Products.List(new QueryOptions<Product>
                {
                    OrderBy = p => p.ProductName
                }),
                Registrations = Data.Registrations.List(new QueryOptions<Registration>
                {
                    Includes = "Customer, Product",
                    Where = r => r.CustomerID == id
                })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Filter(int customerID = 0)
        {
            return RedirectToAction("List", new { ID = customerID });
        }

        [HttpPost]
        public IActionResult Register(RegistrationViewModel model)
        {
            if (model.ProductID == 0)
            {
                TempData["message"] = "You must select a product.";
            }
            else
            {
                Registration registration = new Registration
                {
                    CustomerID = model.CustomerID,
                    ProductID = model.ProductID
                };
                Data.Registrations.Insert(registration);

                try
                {
                    Data.Save();
                }
                catch (DbUpdateException ex)
                {
                    string msg = (ex.InnerException == null) ? ex.Message : ex.InnerException.Message;
                    if (msg.Contains("duplicate key"))
                        TempData["message"] = "This product is already registered to this customer";
                    else
                        TempData["message"] = "Error accessing database: " + msg;
                }
            }
            return RedirectToAction("List", new { ID = model.CustomerID });
        }

        [HttpPost]
        public IActionResult Delete(int customerID, int productID)
        {
            Registration registration = new Registration
            {
                CustomerID = customerID,
                ProductID = productID
            };
            Data.Registrations.Delete(registration);
            Data.Save();
            return RedirectToAction("List", new { ID = customerID });
        }
    }
}
