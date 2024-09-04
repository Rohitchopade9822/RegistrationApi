using Microsoft.AspNetCore.Mvc;
using NewAPIConsume.Models;
using Newtonsoft.Json;

namespace NewAPIConsume.Controllers
{
    public class CourseMaterialViewModelController : Controller
    {
        Uri BaseAddress=new Uri("https://localhost:44368/api/");
        private HttpClient _httpClient;

        public CourseMaterialViewModelController()
        {
            
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAddress;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            List<CourseMaterialViewModel> courseMaterialViewModels =new List<CourseMaterialViewModel>();

            HttpResponseMessage response= await _httpClient.GetAsync("CourseMaterials/GetCourseMaterials");

            
            //https://localhost:44368/api/CourseMaterials/GetCourseMaterials


            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                courseMaterialViewModels = JsonConvert.DeserializeObject<List<CourseMaterialViewModel>>(Data);
            }
            return View(courseMaterialViewModels);

            
        }
    }
}
