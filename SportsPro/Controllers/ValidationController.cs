using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ValidationController : Controller
    {
        private SportsProContext Context { get; set; }
        public ValidationController(SportsProContext ctx) => Context = ctx;
        public JsonResult CheckEmail(string email, int customerID)
        {
            if(customerID == 0)
            {
                string msg = Check.EmailExists(Context, email);
                if(!string.IsNullOrEmpty(msg)) 
                {
                    return Json(msg);
                }
            }
            TempData["okEmail"] = true;
            return Json(true);
        }
    }
}
