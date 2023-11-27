using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.ViewModels;
using System.Net.Http;

namespace SportsPro.Controllers
{
    public class TechIncidentController : Controller
    {
        private SportsProContext Context { get; set; }
        public TechIncidentController(SportsProContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ViewBag.Technicians = Context.Technicians
                                         .OrderBy(t => t.TechnicianName)
                                         .ToList();

            int? techID = HttpContext.Session.GetInt32("techID");
            Technician? technician;
            if (techID == null)
            {
                technician = new Technician();
            }
            else
            {
                technician = Context.Technicians
                                    .Where(t => t.TechnicianID == techID)
                                    .FirstOrDefault();
            }
            return View(technician);
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var model = new TechIncidentViewModel
            {
                Technician = Context.Technicians.Find(id),
                Incidents = Context.Incidents
                                   .Include(i => i.Customer)
                                   .Include(i => i.Product)
                                   .OrderBy(i => i.DateOpened)
                                   .Where(i => i.TechnicianID == id)
                                   .Where(i => i.DateClosed == null)
                                   .ToList()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult List(Technician technician)
        {
            HttpContext.Session.SetInt32("techID", technician.TechnicianID);

            if (technician.TechnicianID == 0)
            {
                TempData["message"] = "You must select a technician";
                return RedirectToAction("Get");
            }
            else
            {
                return RedirectToAction("List", new { id = technician.TechnicianID });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? techID = HttpContext.Session.GetInt32("techID");

            var model = new TechIncidentViewModel
            {
                Technician = Context.Technicians.Find(techID),
                Incident = Context.Incidents
                                  .Include(i => i.Customer)
                                  .Include(i => i.Product)
                                  .FirstOrDefault(i => i.IncidentID == id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel model)
        {
            Incident? i = Context.Incidents.Find(model.Incident?.IncidentID);
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;

            Context.Incidents.Update(i);
            Context.SaveChanges();

            int? techID = HttpContext.Session.GetInt32("techID");
            return RedirectToAction("List", new {id = techID});

        }
    }
}
