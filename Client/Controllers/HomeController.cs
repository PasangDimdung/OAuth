using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Api()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var apiResponse = await _client.GetAsync("https://localhost:44375/secret/index");

            string message = "Api response";

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return Ok(message);
            }
            else
            {
                return Unauthorized();
            };
        }

    }
}
