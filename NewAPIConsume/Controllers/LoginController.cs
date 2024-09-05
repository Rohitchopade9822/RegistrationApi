using Azure;
using Microsoft.AspNetCore.Mvc;
using NewAPIConsume.Models;
using Newtonsoft.Json;
using System.Text;



namespace NewAPIConsume.Controllers
{
    public class LoginController : Controller
    {

        Uri BaseAddress = new Uri("https://localhost:44368/api/");
        private readonly HttpClient _httpClient;
        public LoginController()
        {

            _httpClient = new HttpClient();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Loginuser(LoginViewModel login)
        {

            var content = new StringContent(
                JsonConvert.SerializeObject(login),
                Encoding.UTF8,
                "application/json");

            // Send POST request to Web API login endpoint
            using (var response = _httpClient.PostAsync("https://localhost:44368/api/Authentication/UserLogin", content).Result)
            {

                string token = response.Content.ReadAsStringAsync().Result;

                if (token == "Invalid username or password.")
                {
                    ViewBag.Message = "incorrect passwprd or username";

                    //ModelState.AddModelError("Username", "Invalid username or password.");
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return View("Index", login);
                  //  return View("~/Login/Index"); // Redirect to protected area
                }
                HttpContext.Session.SetString("token", token);

            }

            return Redirect("~/Dashboard/Index");
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("~/Login/Index");

        }
    }
}
