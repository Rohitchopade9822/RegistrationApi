using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationApi.DBModel;

namespace NewAPIConsume.Controllers
{
    public class EnrollmentController : Controller
    {
        Uri BaseAddress = new Uri("https://localhost:44368/api/");

        private readonly HttpClient _httpClient;

        public EnrollmentController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAddress;
        }
        
         
        public async Task<IActionResult> Index()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
              "Enrollment");

            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                enrollments = JsonConvert.DeserializeObject<List<Enrollment>>(Data);
            }

            return View(enrollments);

        }
    }
}
