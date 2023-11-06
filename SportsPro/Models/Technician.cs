using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
        public int TechnicianID { get; set; }

        [Required]
        public string TechnicianName { get; set; } = string.Empty;

        [Required]
        public string TechnicianEmail { get; set; } = string.Empty;

        [Required]
        public string TechnicianPhone { get; set; } = string.Empty;
    }
}
