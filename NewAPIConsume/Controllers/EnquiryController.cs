
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace NewAPIConsume.Controllers
{
    public class EnquiryController : Controller
    {
        Uri BaseAddress = new Uri("https://localhost:44368/api/");
      
        private HttpClient _httpClient;

        public EnquiryController()
        {
            _httpClient = new HttpClient(); 
            _httpClient.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            List< Enquiry > enquiries = new List< Enquiry >();

            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
            "Enquiry");

            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                enquiries = JsonConvert.DeserializeObject<List<Enquiry>>(Data);
            }


            return View(enquiries);

            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Enquiry enquiry)
        {

            string data = JsonConvert.SerializeObject(enquiry);

            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
        
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress +
                "Enquiry", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
