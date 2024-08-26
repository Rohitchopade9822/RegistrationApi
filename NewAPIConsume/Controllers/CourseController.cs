using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace NewAPIConsume.Controllers
{
    public class CourseController : Controller
    {
        Uri BaseAddress=new Uri("https://localhost:44368/api/");
        
        private HttpClient _httpClient;
        public CourseController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            List< Course > courseslist = new List< Course >();
            HttpResponseMessage response=await _httpClient.GetAsync("Course/GetCourses");

            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                courseslist = JsonConvert.DeserializeObject<List<Course>>(Data);
            }
            return View(courseslist);

            
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {

            string data = JsonConvert.SerializeObject(course);

            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress +
                "Course/AddCourses", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
