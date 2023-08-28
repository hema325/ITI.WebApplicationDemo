using ITI.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeRefactorings;
using System.Diagnostics;
using System.Text.Json;

namespace ITI.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCookie(int id,string name)
        {
            Response.Cookies.Append("cookie", JsonSerializer.Serialize(new { id, name }));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ShowCookie(int id, string name)
        {
            Request.Cookies.TryGetValue("cookie", out var result);

            if (result != null)
                return Ok(JsonSerializer.Deserialize<object>(result));

            return NoContent();
        }

        public IActionResult SetSession(int id, string name)
        {
            HttpContext.Session.SetString("session", JsonSerializer.Serialize(new { id, name }));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ShowSession(int id, string name)
        {
            var result = HttpContext.Session.GetString("session");

            if (result != null)
                return Ok(JsonSerializer.Deserialize<object>(result));

            return NoContent();
        }
    }
}