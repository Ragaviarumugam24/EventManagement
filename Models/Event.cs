using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        public string? Location { get; set; }

        public int Registrations { get; set; } = 0;
    }
}
