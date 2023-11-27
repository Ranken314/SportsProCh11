using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext Context {  get; set; }
        public IncidentController(SportsProContext ctx)
        {
            Context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Incident> incidents = Context.Incidents
                                               .Include(i => i.Customer)
                                               .Include(i => i.Product)
                                               .OrderBy(i => i.DateOpened)
                                               .ToList();
            return View(incidents);
        }
        public void StoreListsInViewBag()
        {
            ViewBag.Customer = Context.Customers
                                        .OrderBy(c => c.FirstName)
                                        .ToList();

            ViewBag.Product = Context.Products
                                      .OrderBy(p => p.ProductName)
                                      .ToList();

            ViewBag.Technician = Context.Technicians
                                        .OrderBy(t => t.TechnicianName);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            StoreListsInViewBag();
            return base.View("AddEdit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            StoreListsInViewBag();
            var incident = Context.Incidents.Find(id);
            return View("AddEdit", incident);
        }

        [HttpPost]
        public IActionResult Save(Incident incident)
        {
            if(ModelState.IsValid)
            {
                if(incident.IncidentID == 0)
                {
                    Context.Incidents.Add(incident);
                }
                else
                {
                    Context.Incidents.Update(incident);
                }
                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                StoreListsInViewBag();
                if(incident.IncidentID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View("AddEdit", incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = Context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            Context.Incidents.Remove(incident);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
