using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }




 


}
