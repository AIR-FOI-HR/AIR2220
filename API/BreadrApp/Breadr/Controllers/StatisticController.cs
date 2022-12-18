using Microsoft.AspNetCore.Mvc;

namespace Breadr.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
