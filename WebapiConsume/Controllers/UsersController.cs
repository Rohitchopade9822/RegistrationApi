using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebapiConsume.Models;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace WebapiConsume.Controllers
{
    public class UsersController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:44329/api");
        private readonly HttpClient _Client;

        public UsersController()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = baseAddress;

        }

       
        
            
        
    }
}
