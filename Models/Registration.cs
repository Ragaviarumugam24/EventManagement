using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required] public string FullName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }

        [Required] public int EventId { get; set; }
    }
}
