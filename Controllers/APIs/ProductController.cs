using IdentityWithJWT_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithJWT_App.Controllers.APIs
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        public List<string> GetProducts()
        {
            return new List<string>() { "Product1", "Product2" };
        }
    }
}
