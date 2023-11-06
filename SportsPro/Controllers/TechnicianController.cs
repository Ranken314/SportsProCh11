using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext Context {  get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            Context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Technician> tech = Context.Technicians
                                     .OrderBy(t => t.TechnicianName)
                                     .ToList();
            return View(tech);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var tech = Context.Technicians.Find(id);
            return View("AddEdit", tech);
        }

        [HttpPost]
        public IActionResult Save(Technician tech)
        {
            if (ModelState.IsValid)
            {
                if (tech.TechnicianID == 0)
                {
                    Context.Technicians.Add(tech);
                }
                else
                {
                    Context.Technicians.Update(tech);
                }
                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (tech.TechnicianID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View(tech);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tech = Context.Technicians.Find(id);
            return View(tech);
        }

        [HttpPost]
        public IActionResult Delete(Technician tech)
        {
            Context.Technicians.Remove(tech);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
