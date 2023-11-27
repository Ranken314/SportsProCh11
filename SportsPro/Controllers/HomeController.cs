using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }


    }
}