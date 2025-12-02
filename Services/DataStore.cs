

using EventManagement.Models;

namespace EventManagement.Services
{
    // simple in-memory store used for demo / development
    public class DataStore
    {
        private readonly List<Event> _events = new();
        private readonly List<ContactMessage> _messages = new();
        private readonly List<Registration> _registrations = new();
        private int _eventId = 1;
        private int _messageId = 1;
        private int _registrationId = 1;

        public DataStore()
        {
            // seed example events
            AddEvent(new Event
            {
                Title = "Modern Web Dev Summit",
                Description = "A practical summit for frontend & backend engineers.",
                EventDate = DateTime.UtcNow.AddDays(20),
                Location = "Hyderabad International Convention Centre",
            });
            AddEvent(new Event
            {
                Title = "Open-Air Music Festival",
                Description = "Two days of live bands and food trucks.",
                EventDate = DateTime.UtcNow.AddDays(45),
                Location = "City Central Park",
            });
        }

        public List<Event> GetEvents() => _events;

        public Event? GetEvent(int id) => _events.FirstOrDefault(e => e.Id == id);

        public void AddEvent(Event ev)
        {
            ev.Id = _eventId++;
            _events.Add(ev);
        }

        public void UpdateEvent(Event ev)
        {
            var existing = GetEvent(ev.Id);
            if (existing is null) return;
            existing.Title = ev.Title;
            existing.Description = ev.Description;
            existing.EventDate = ev.EventDate;
            existing.Location = ev.Location;
        }

        public void DeleteEvent(int id)
        {
            var ev = GetEvent(id);
            if (ev != null) _events.Remove(ev);
        }

        public void AddMessage(ContactMessage msg)
        {
            msg.Id = _messageId++;
            _messages.Add(msg);
        }

        public List<ContactMessage> GetMessages() => _messages;

        public void AddRegistration(Registration reg)
        {
            reg.Id = _registrationId++;
            _registrations.Add(reg);
            var ev = GetEvent(reg.EventId);
            if (ev != null) ev.Registrations++;
        }

        public List<Registration> GetRegistrations() => _registrations;
    }
}
