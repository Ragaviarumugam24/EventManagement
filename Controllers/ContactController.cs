using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataStore _dataStore;
        public ContactController(DataStore dataStore) => _dataStore = dataStore;

        [HttpGet]
        public IActionResult Index() => View(new ContactMessage());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(ContactMessage model)
        {
            if (!ModelState.IsValid) return View(model);
            _dataStore.AddMessage(model);
            ViewBag.Success = "Your message has been sent successfully!";
            return View(new ContactMessage());
        }
    }
}
