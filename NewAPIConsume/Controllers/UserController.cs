using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
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
				return RedirectToAction("Index");
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
					TempData["successmsg"] = "user updated"; /*//https://localhost:44368/api/User/UpdateUser?id=1*/
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
        [HttpGet]
        public ActionResult Delete(int id)
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
        public async Task<ActionResult> Delete(int id, UserModel model)
        {

            try
            {
                string data = JsonConvert.SerializeObject(model);
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
