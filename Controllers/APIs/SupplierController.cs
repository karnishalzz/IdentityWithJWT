using IdentityWithJWT_App.Data;
using IdentityWithJWT_App.Models.Entities;
using IdentityWithJWT_App.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityWithJWT_App.Controllers.APIs
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        
        
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService=supplierService;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<object> GetList()
        {
            return await _supplierService.GetListAsync();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public async Task<object> GetDetail(int id)
        {
            return await _supplierService.FindByIdAsync(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<object> CreateSupplier([Bind("Name,ContactNo,Email,City,PostalCode,Country,Image")] Supplier supplier)
        {
            return await _supplierService.CreateAsync(supplier);
        }

        // PUT api/<SupplierController>/5
        [HttpPost("{id}")]
        public async Task<object> UpdateSupplier([Bind("Id,Name,ContactNo,Email,City,PostalCode,Country,IsActive,Image")]  Supplier supplier)
        {
          return await _supplierService.UpdateAsync(supplier);
        }

        // DELETE api/<SupplierController>/5
        [HttpPost("{id}")]
        public async Task<object> DeleteSupplier(int id)
        {
           return await _supplierService.DeleteAsync(id);
        }
    }
}
