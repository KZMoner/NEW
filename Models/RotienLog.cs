using System.ComponentModel.DataAnnotations;

namespace New.Models;

public class RotienLog
{
   [Key]
        public int Id { get; set; } // Unique ID for the log entry

        [Required]
        public string UserName { get; set; } = string.Empty; // Who did the action

        [Required]
        public string Action { get; set; } = string.Empty; // "Created", "Updated", "Deleted"

        [Required]
        public int RotienId { get; set; } // The ID of the rotien affected

        [Required]
        public DateTime DateTime { get; set; } = DateTime.UtcNow; // When it happened
}
