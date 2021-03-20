using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityWithJWT_App.Models.Entities;

namespace IdentityWithJWT_App.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Suppliers.Any()) { return; }

            Supplier[] suppliers = new Supplier[]
            {
            new Supplier{Name="Pran",ContactNo="01234567890",Email="pran@email.com",City="Dhaka",Country="Bangladesh",PostalCode="1234",ImagePath="N/A",IsActive=true },
            new Supplier{Name="Coca Cola",ContactNo="01234567890",Email="cocacola@email.com",City="Dhaka",Country="Bangladesh",PostalCode="1234",ImagePath="N/A",IsActive=true },
            new Supplier{Name="Nescafe",ContactNo="01234567890",Email="Nescafe@email.com",City="Dhaka",Country="Bangladesh",PostalCode="1234",ImagePath="N/A",IsActive=true },
            new Supplier{Name="Dada",ContactNo="01234567890",Email="dada@email.com",City="Dhaka",Country="Bangladesh",PostalCode="1234",ImagePath="N/A",IsActive=true },
            new Supplier{Name="Complan",ContactNo="01234567890",Email="complan@email.com",City="Dhaka",Country="Bangladesh",PostalCode="1234",ImagePath="N/A",IsActive=true },
            };
            foreach (Supplier c in suppliers)
            {
                context.Suppliers.Add(c);
            }
            context.SaveChanges();

        }
    }
}
