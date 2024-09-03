using Microsoft.AspNetCore.Mvc;

namespace NewAPIConsume.Controllers
{
    public class EducatorDashbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
