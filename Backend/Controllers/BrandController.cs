#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using SharedDO;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly VehicleContext _context;

        public BrandController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDO>>> GetBrandSet()
        {
            var brands = new List<BrandDO>();
            foreach (var b in await _context.BrandSet.ToListAsync())
            {
                brands.Add(new BrandDO
                {
                    Brand = b.BrandName,
                });
            }
            return brands;
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDO>> GetBrand(string id)
        {
            var brand = await _context.BrandSet.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return new BrandDO { Brand = brand.BrandName };
        }
    }
}
