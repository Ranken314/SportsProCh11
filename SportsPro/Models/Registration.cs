using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Registration
    {
        // Composite primary key and foreign keys
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}
