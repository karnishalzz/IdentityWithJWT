using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithJWT_App.Models.SupplierModels
{
    public class SupplierDetails
    {
        public int Id { get; set; }

        [DisplayName("Supplier Name")]
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
}
