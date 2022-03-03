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
    public class FuelTypeController : ControllerBase
    {
        private readonly VehicleContext _context;

        public FuelTypeController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/FuelType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelDO>>> GetFuelTypes()
        {
            var fuels = new List<FuelDO>();
            foreach (var f in await _context.FuelTypes.ToListAsync())
            {
                fuels.Add(new FuelDO { Fuel = f.Type });
            }
            return fuels;
        }

        // GET: api/FuelType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuelDO>> GetFuelType(string id)
        {
            var fuelType = await _context.FuelTypes.FindAsync(id);

            if (fuelType == null)
            {
                return NotFound();
            }

            return new FuelDO { Fuel = fuelType.Type };
        }
    }
}
