//using ConsumeAPI.Models;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//namespace ConsumeAPI.Controllers
//{
//	public class UsersController : Controller
//	{
//		Uri BaseAddress = new Uri("https://localhost:44368/api");
//		private readonly HttpClient _httpClient;

//        public UsersController()
//        {
//            _httpClient = new HttpClient();
//			_httpClient.BaseAddress = BaseAddress;
//        }

//		[HttpGet]
//		public async Task  <IActionResult> Index()
//		{
			
//				List<UserViewModel> userslist = new List<UserViewModel>();
//				HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress +
//				"/User/GetallUser");

//				if(response.IsSuccessStatusCode)
//				{
//					var Data = response.Content.ReadAsStringAsync().Result;

//					userslist = JsonConvert.DeserializeObject<List<UserViewModel>>(Data);
//				}

//				return View(userslist);
			
//		}
//		[HttpGet]
//		public IActionResult Create()
//		{

//			return View();

//		}

//		[HttpPost]
//		public async Task <IActionResult> Create(UserViewModel userViewModel)
//		{

//			string data = JsonConvert.SerializeObject(userViewModel);

//			StringContent stringContent = new StringContent(data, Encoding.UTF8,"application/json");
			
//			HttpResponseMessage response = await  _httpClient.PostAsync(_httpClient.BaseAddress +
//				"/User/AddUser", stringContent);

//			if (response.IsSuccessStatusCode)
//			{
//				return RedirectToAction("Index");
//			}
//			return View();
			
//		}
//		[HttpGet]
//		public async Task<IActionResult> Edit(int id)
//		{
//			UserViewModel user = new UserViewModel();

//			try
//			{
//				var url = $"{_httpClient.BaseAddress}/User/GetUserbyid?id={id}";

//				var response = await _httpClient.GetAsync(url);

//				response.EnsureSuccessStatusCode(); // Throws if not successful

//				var data = await response.Content.ReadAsStringAsync();

//				user = JsonConvert.DeserializeObject<UserViewModel>(data);
//			}
//			catch (HttpRequestException ex)
//			{
//				// Handle the exception, e.g., log, return error message
//				return BadRequest("Error fetching user data: " + ex.Message);
//			}

//			return View(user);
//		}


//		[HttpPost]
//		public async Task<IActionResult> Edit(UserViewModel userViewModel)
//		{
//			if (userViewModel.UserId == null)
//			{
//				return BadRequest();
//			}

//			var jsonContent = JsonContent.Create(userViewModel); // Use JsonContent for better serialization

//			var response = await _httpClient.PutAsync(_httpClient.BaseAddress + "/User/UpdateUser", jsonContent);


//			if (response.IsSuccessStatusCode)
//			{
//				TempData["successMessage"] = "updated";
//				return RedirectToAction("Index"); // Or RedirectToAction if needed
//			}

//			return BadRequest(); // Handle error, e.g., return View(userViewModel) with error messages
//		}
//		//[HttpGet]
//		//public IActionResult Delete(int id)
//		//{
//		//	try
//		//	{
//		//		UserViewModel user = new UserViewModel();

//		//		HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/User/DeleteUser" + id).Result;

//		//		if (response.IsSuccessStatusCode)
//		//		{
//		//			string data = response.Content.ReadAsStringAsync().Result;
//		//			user = JsonConvert.DeserializeObject<UserViewModel>(data);

//		//		}
				
//		//	}
//		//	catch(Exception  ex)
//		//	{
//		//		throw;
//		//	}
			


		
		
//	}
//}
