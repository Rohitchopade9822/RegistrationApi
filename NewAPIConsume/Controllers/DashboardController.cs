using Microsoft.AspNetCore.Mvc;

namespace NewAPIConsume.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
    }
}
