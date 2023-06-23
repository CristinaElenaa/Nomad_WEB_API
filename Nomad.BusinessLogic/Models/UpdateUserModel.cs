using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.BusinessLogic.Models
{
    public class UpdateUserModel
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string County { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
