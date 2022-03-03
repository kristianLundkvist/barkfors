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
    public class VehicleEquipmentController : ControllerBase
    {
        private readonly VehicleContext _context;

        public VehicleEquipmentController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/VehicleEquipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleEquipmentDO>>> GetEquipment()
        {
            var equipment = new List<VehicleEquipmentDO>();
            foreach (var ve in await _context.Equipment.ToListAsync())
            {
                equipment.Add(new VehicleEquipmentDO
                {
                    VehicleEquipment = ve.Equipment,
                });
            }
            return equipment;
        }

        // GET: api/VehicleEquipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleEquipmentDO>> GetVehicleEquipment(string id)
        {
            var vehicleEquipment = await _context.Equipment.FindAsync(id);

            if (vehicleEquipment == null)
            {
                return NotFound();
            }

            return new VehicleEquipmentDO { VehicleEquipment = vehicleEquipment.Equipment };
        }
    }
}
