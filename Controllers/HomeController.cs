using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataStore _dataStore;
        public HomeController(DataStore dataStore) => _dataStore = dataStore;

        public IActionResult Index()
        {
            var events = _dataStore.GetEvents().OrderBy(e => e.EventDate).ToList();
            return View(events);
        }

        public IActionResult About() => View();
        public IActionResult Services() => View();
    }
}
