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
    public class ColorController : ControllerBase
    {
        private readonly VehicleContext _context;

        public ColorController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/Color
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorDO>>> GetColors()
        {
            var colors = new List<ColorDO>();
            foreach (var c in await _context.Colors.ToListAsync())
            {
                colors.Add(new ColorDO
                {
                    Color = c.ColorName,
                });
            }
            return colors;
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDO>> GetCarColor(string id)
        {
            var carColor = await _context.Colors.FindAsync(id);

            if (carColor == null)
            {
                return NotFound();
            }

            return new ColorDO { Color = carColor.ColorName };
        }
    }
}
