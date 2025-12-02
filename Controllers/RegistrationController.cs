using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataStore _dataStore;
        public RegistrationController(DataStore dataStore) => _dataStore = dataStore;

        public IActionResult Register(int id)
        {
            var ev = _dataStore.GetEvent(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RegisterConfirmed(int id, string fullName, string email, string phone)
        {
            var ev = _dataStore.GetEvent(id);
            if (ev == null) return NotFound();

            var reg = new Registration
            {
                EventId = id,
                FullName = fullName,
                Email = email,
                Phone = phone
            };

            _dataStore.AddRegistration(reg);
            ViewBag.Message = "You are registered successfully!";
            return View("Register", ev);
        }
    }
}
