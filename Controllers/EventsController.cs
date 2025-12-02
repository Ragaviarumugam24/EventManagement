using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.Services;

namespace EventManagement.Controllers
{
    public class EventsController : Controller
    {
        private readonly DataStore _dataStore;
        public EventsController(DataStore dataStore) => _dataStore = dataStore;

        public IActionResult Index() => View(_dataStore.GetEvents().OrderBy(e => e.EventDate).ToList());

        public IActionResult Details(int id)
        {
            var ev = _dataStore.GetEvent(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev)
        {
            if (!ModelState.IsValid) return View(ev);
            _dataStore.AddEvent(ev);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var ev = _dataStore.GetEvent(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event ev)
        {
            if (!ModelState.IsValid) return View(ev);
            _dataStore.UpdateEvent(ev);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var ev = _dataStore.GetEvent(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataStore.DeleteEvent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
