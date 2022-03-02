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
    public class VehicleEquipmentController : ControllerBase
    {
        private readonly VehicleContext _context;

        public VehicleEquipmentController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/VehicleEquipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleEquipment>>> GetEquipment()
        {
            return await _context.Equipment.ToListAsync();
        }

        // GET: api/VehicleEquipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleEquipment>> GetVehicleEquipment(int id)
        {
            var vehicleEquipment = await _context.Equipment.FindAsync(id);

            if (vehicleEquipment == null)
            {
                return NotFound();
            }

            return vehicleEquipment;
        }
    }
}
