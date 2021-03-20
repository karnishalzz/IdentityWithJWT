using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithJWT_App.Models.SupplierModels
{
    public class CreateSupplier
    {

        [Required]
        [DisplayName("Supplier Name")]
        [MinLength(4, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [MinLength(11, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(11, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string ContactNo{ get; set; }

        [Required]
        [DisplayName("Email")]
        [MinLength(8, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("City")]
        [MinLength(4, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Country")]
        [MinLength(2, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50)]
        public string Country { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
