
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewAPIConsume.Models;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace NewAPIConsume.Controllers
{
	public class UserController : Controller
	{
		Uri BaseAddress = new Uri("https://localhost:44368/api");
		private readonly HttpClient _httpClient;

        public UserController()
        {
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = BaseAddress;

		}
      
		[HttpGet]
        public async Task<IActionResult> Index()
		{

            var access_token=HttpContext.Session.GetString("token");

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            List<UserModel> userslist = new List<UserModel>();
			HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
			"/User/GetallUser");

			if (response.IsSuccessStatusCode)
			{
				var Data = response.Content.ReadAsStringAsync().Result;

				userslist = JsonConvert.DeserializeObject<List<UserModel>>(Data);
			}


			return View(userslist);

		}

		[HttpGet]
		public IActionResult Create()
		{
			List<SelectListItem> roles = new List<SelectListItem>()
		   {new SelectListItem { Text = "Student", Value = "Student" },
			new SelectListItem{ Text="Educator",Value="Educator"},

			};
			ViewBag.user_roles = roles;


			return View();
		}

	    [HttpPost]
		public async Task<IActionResult> Create(UserModel userModel)
		{
       

            string data = JsonConvert.SerializeObject(userModel);

			StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress +
				"/User/AddUser", stringContent);

			if (response.IsSuccessStatusCode)
			{
				return View("~/Views/SuccessView.cshtml");
			}
			return View();

		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			try
			{
				UserModel flight = new UserModel();
				HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/User/GetUserbyid?id=" + id).Result;
				if (response.IsSuccessStatusCode)
				{
					string data = response.Content.ReadAsStringAsync().Result;
					flight = JsonConvert.DeserializeObject<UserModel>(data);
				}
				return View(flight);
			}
			catch (Exception ex)
			{

				TempData["errormsg"] = ex.Message;
				return View();
			}

		}
		[HttpPost]
		public async Task<ActionResult> Edit(int id, UserModel model)
		{

			try
			{
				string data = JsonConvert.SerializeObject(model);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await _httpClient.PutAsync(_httpClient.BaseAddress + "/User/UpdateUser?id=" + id, content);
				if (response.IsSuccessStatusCode)
				{
					TempData["successmsg"] = "user updated"; 
                    return RedirectToAction("Dashboard");
				}

			}
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
                Material flight = new Material();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/User/GetUserbyid?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    flight = JsonConvert.DeserializeObject<Material>(data);
                }
                return View(flight);
            }
            catch (Exception ex)
            {

                TempData["errormsg"] = ex.Message;
                return View();
            }

        }
		[HttpPost]
        public async Task<ActionResult> Delete(int id, Material material)
        {

            try
            {
                string data = JsonConvert.SerializeObject(material);
             //   StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.DeleteAsync(_httpClient.BaseAddress + "/User/DeleteUser?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successmsg"] = "user Deleted"; /*//https://localhost:44368/api/User/UpdateUser?id=1*/
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errormsg"] = ex.Message;
                return View();
            }


            return View();
        }

    }
}
