using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required (ErrorMessage = "You must supply a first name.")]
        [StringLength (50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must supply a last name.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must supply a address.")]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must supply a city.")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must supply a state.")]
        [StringLength(50)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must supply a postal code.")]
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string CountryID { get; set; } = string.Empty;

        [ValidateNever]
        public Country? Country { get; set; }

        [RegularExpression(@"^((\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$", 
            ErrorMessage = "Phone number must be in a (999) 999-9999 format." )]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage ="You must supply an email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmail", "Validation", AdditionalFields ="CustomerID")]
        public string Email {  get; set; } = string.Empty; 
        public ICollection<Registration>? Registrations { get; set; }

        public string FullName => FirstName + "" + LastName;

    }
}
