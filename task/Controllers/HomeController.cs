using Microsoft.AspNetCore.Mvc;
using WebApplication4.contexts;
using WebApplication4.viewModel;

namespace WebApplication4.Controllers
{
	public class HomeController : Controller
    {
        private readonly ProniaDbContext _context;

        public HomeController(ProniaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Shippings = _context.Shippings.ToList(),
            };
            return View(model);
        }
    }
}
