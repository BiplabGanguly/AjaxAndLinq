using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter ID")]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "First name cannot contain numbers.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Last name cannot contain numbers.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be a 10-digit number.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code must be a 5-digit number.")]
        public string ZipCode { get; set; }
    }
}
