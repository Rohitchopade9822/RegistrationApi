
using Microsoft.AspNetCore.Mvc;
using NewAPIConsume.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewAPIConsume.Controllers
{
    public class MaterialController : Controller
    {

        Uri BaseAddress = new Uri("https://localhost:44368/api/");

        private HttpClient _httpClient;

        public MaterialController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAddress;
        }
        [HttpGet]
        public async Task <IActionResult> Index(Material material)
        {
            List<Material> materials = new List<Material>();

            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
            "Materials/GetMaterials");

            //https://localhost:44368/api/Materials/GetMaterials

            if (response.IsSuccessStatusCode)
            {
                var Data = response.Content.ReadAsStringAsync().Result;

                materials = JsonConvert.DeserializeObject<List<Material>>(Data);
            }

            return View(materials);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public async Task <IActionResult> Create(Material material)
        {
           string data=JsonConvert.SerializeObject(material);

            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress +
                "Materials", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Material material = new Material();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Materials/IdbyMaterial?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    material = JsonConvert.DeserializeObject<Material>(data);
                }
                return View(material);
            }//https://localhost:44368/api/Materials/IdbyMaterial?id=1
            catch (Exception ex)
            {

                TempData["errormsg"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Material material)
        {

            try
            {
                string data = JsonConvert.SerializeObject(material);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(_httpClient.BaseAddress + "Materials/UpdateMaterial/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successmsg"] = "Material updated";
                    return RedirectToAction("Index");
                }

            }//https://localhost:44368/api/Materials/UpdateMaterial/1
            catch (Exception ex)
            {

                TempData["errormsg"] = ex.Message;
                return View();
            }


            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Material material = new Material();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Materials/IdbyMaterial?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    material = JsonConvert.DeserializeObject<Material>(data);
                }
                return View(material);
            }//https://localhost:44368/api/Materials/DeleteMaterial?id=1
            catch (Exception ex)
            {

                TempData["errormsg"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public ActionResult Delete(int id,Material material)
        {
            try
            {
                string data = JsonConvert.SerializeObject(material);
                HttpResponseMessage response =  _httpClient.DeleteAsync(_httpClient.BaseAddress + "Materials/DeleteMaterial?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successmsg"] = "user Deleted"; /*//https://localhost:44368/api/User/UpdateUser?id=1*/
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View();
        }
    }
}
