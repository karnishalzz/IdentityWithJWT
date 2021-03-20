using IdentityWithJWT_App.Data;
using IdentityWithJWT_App.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithJWT_App.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public ImageUploader _imageUploader = new ImageUploader();
        private readonly IWebHostEnvironment _env;

        public SupplierService(ApplicationDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<object> CreateAsync(Supplier supplier)
        {
            try
            {
                string applicationImagePath = Path.Combine(_env.WebRootPath + $"{Path.DirectorySeparatorChar}SupplierImages{Path.DirectorySeparatorChar}");
                //wwwroot/Users/
                string dbImagePath = Path.Combine($"{Path.DirectorySeparatorChar}SupplierImages{Path.DirectorySeparatorChar}");
                //Users/



                if (supplier.Image != null)
                {
                    string dbPath = _imageUploader.UploadImages(supplier.Image, applicationImagePath, dbImagePath);
                    supplier.ImagePath = dbPath ?? "N/A";
                }
                else { supplier.ImagePath = "N/A"; }
                supplier.IsActive = true;
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();

                return new
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
           
        }

        public async Task<object> DeleteAsync(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.FindAsync(id);

                supplier.IsActive = false;
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();

                return new
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
           
        }

        public async Task<object> FindByIdAsync(int id)
        {
            try
            {
                var data = await _context.Suppliers.FindAsync(id);
      
                return new
                {
                    Success = true,
                    Record = data
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
           
        }

        public async Task<object> GetListAsync()
        {
            try
            {
                var data = await _context.Suppliers
                .Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();

                return new
                {
                    Success = true,
                    Records = data
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public bool IsExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }

        public async Task<object> UpdateAsync(Supplier supplier)
        {
            try
            {
                var supplierToBeUpdated = await _context.Suppliers.FindAsync(supplier.Id);
                supplierToBeUpdated.Name = supplier.Name;
                supplierToBeUpdated.ContactNo = supplier.ContactNo;
                supplierToBeUpdated.Email = supplier.Email;
                supplierToBeUpdated.City = supplier.City;
                supplierToBeUpdated.PostalCode = supplier.PostalCode;
                supplierToBeUpdated.Country = supplier.Country;
                supplierToBeUpdated.IsActive = supplier.IsActive;

                string applicationImagePath = Path.Combine(_env.WebRootPath + $"{Path.DirectorySeparatorChar}SupplierImages{Path.DirectorySeparatorChar}");
                //wwwroot/Users/
                string dbImagePath = Path.Combine($"{Path.DirectorySeparatorChar}SupplierImages{Path.DirectorySeparatorChar}");
                //Users/
                if (supplier.Image != null)
                {

                    string dbPath = _imageUploader.UploadImages(supplier.Image, applicationImagePath, dbImagePath);
                    if (dbPath != null)
                    {
                        _imageUploader.DeleteImageDirectory(_env.WebRootPath + $"{Path.DirectorySeparatorChar}" + supplierToBeUpdated.ImagePath);
                        supplierToBeUpdated.ImagePath = dbPath;
                    }

                }
                _context.Suppliers.Update(supplierToBeUpdated);
                await _context.SaveChangesAsync();
                return new
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }

            
        }
    }
    public interface ISupplierService
    {
       Task<object> CreateAsync(Supplier supplier);
       Task<object> DeleteAsync(int id);
       Task<object> FindByIdAsync(int id);
       Task<object> GetListAsync();
       bool IsExists(int id);
       Task<object> UpdateAsync(Supplier supplier);
    }
 }
