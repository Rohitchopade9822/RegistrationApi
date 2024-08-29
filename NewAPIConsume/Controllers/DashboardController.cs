using Microsoft.AspNetCore.Mvc;

namespace NewAPIConsume.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //Uri BaseAddress = new Uri("https://localhost:44368/api");

            //private readonly HttpClient _httpClient;

            return View();
        }
    }
}
