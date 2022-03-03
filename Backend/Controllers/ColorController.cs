#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly VehicleContext _context;

        public ColorController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/Color
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarColor>>> GetColors()
        {
            return await _context.Colors.ToListAsync();
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarColor>> GetCarColor(string id)
        {
            var carColor = await _context.Colors.FindAsync(id);

            if (carColor == null)
            {
                return NotFound();
            }

            return carColor;
        }
    }
}
