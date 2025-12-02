using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;
using Microsoft.Extensions.Configuration;

namespace EventManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DataStore _dataStore;
        private readonly IConfiguration _config;
        private const string SessionKey = "IsAdmin";

        public DashboardController(DataStore dataStore, IConfiguration config)
        {
            _dataStore = dataStore;
            _config = config;
        }

        public IActionResult Index()
        {
            if (!IsAdmin()) return RedirectToAction("Login");
            var events = _dataStore.GetEvents().OrderBy(e => e.EventDate).ToList();
            var messages = _dataStore.GetMessages();
            ViewBag.Events = events;
            ViewBag.Messages = messages;
            return View();
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string password)
        {
            var adminPass = _config.GetValue<string>("Admin:Password") ?? "admin123";
            if (password == adminPass)
            {
                HttpContext.Session.SetString(SessionKey, "1");
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Invalid password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey);
            return RedirectToAction("Index", "Home");
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString(SessionKey) == "1";
        }
    }
}
