using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationApi.DBModel;
using System.Drawing.Printing;
using System.Text;

namespace NewAPIConsume.Controllers
{
    public class FeedBackController : Controller
    {
        Uri BaseAddress = new Uri("https://localhost:44368/api/");

      

        private HttpClient _httpClient;

        public FeedBackController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAddress;
        }
        
        public async Task <IActionResult> Index()
        {
            List<Feedback> feedbacks = new List<Feedback>();

            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
             "FeedBack/GetFeedback");
            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                feedbacks =  JsonConvert.DeserializeObject<List<Feedback>>(Data);
            }


            return View(feedbacks);

          
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Feedback feedback)
        {

            string data = JsonConvert.SerializeObject(feedback);

            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress +
                "FeedBack/AddFeedback", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
