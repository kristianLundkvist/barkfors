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
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _context;

        public VehicleController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDO>>> GetVehicles()
        {
            var vehicles = new List<VehicleDO>();
            foreach (var v in await _context.Vehicles.ToListAsync())
            {

                VehicleDO temp = new VehicleDO
                {
                    VIN = v.VIN,
                    LicensePlate = v.LicensePlate,
                    Model = v.Model,
                };
                vehicles.Add(ApplyOptionals(temp));
            }
            return vehicles;
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDO>> GetVehicle(string id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var DO = new VehicleDO
            {
                VIN = vehicle.VIN,
                LicensePlate = vehicle.LicensePlate,
                Model = vehicle.Model,
            };
            DO = ApplyOptionals(DO);

            return DO;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(string id, VehicleDO vehicle)
        {
            if (id != vehicle.VIN)
            {
                return BadRequest();
            }

            var vehicleEntity = _context.Vehicles.Find(id);
            if (vehicleEntity == null)
            {
                return NotFound();
            }

            _context.Entry(vehicleEntity).State = EntityState.Modified;
            vehicleEntity.LicensePlate = vehicle.LicensePlate;
            vehicleEntity.Model = vehicle.Model;

            if (vehicle.Brand != null)
            {
                if (_context.BrandSet.Where(b => b.BrandName == vehicle.Brand.Brand).Any())
                {
                    foreach (var b in _context.BrandSet)
                    {
                        if (b.VIN.Exists(v => v.VIN == vehicle.VIN))
                        {
                            b.VIN.Remove(b.VIN.Find(v => v.VIN == vehicle.VIN));
                        }
                    }
                }
                else
                {
                    return BadRequest();
                }

                var brand = _context.BrandSet.Find(vehicle.Brand.Brand);
                brand.VIN.Add(vehicleEntity);
                _context.BrandSet.Update(brand);
            }

            if (vehicle.Fuel != null)
            {
                if (_context.FuelTypes.Where(f => f.Type == vehicle.Fuel.Fuel).Any())
                {
                    foreach (var f in _context.FuelTypes)
                    {
                        if (f.VIN.Exists(v => v.VIN == vehicle.VIN))
                        {
                            f.VIN.Remove(f.VIN.Find(v => v.VIN == vehicle.VIN));
                        }
                    }
                }
                else
                {
                    return BadRequest();
                }

                var fuel = _context.FuelTypes.Find(vehicle.Fuel.Fuel);
                fuel.VIN.Add(vehicleEntity);
                _context.FuelTypes.Update(fuel);
            }

            if (vehicle.Color != null)
            {
                if (_context.Colors.Where(c => c.ColorName == vehicle.Color.Color).Any())
                {
                    foreach (var c in _context.Colors)
                    {
                        if (c.VIN.Exists(v => v.VIN == vehicle.VIN))
                        {
                            c.VIN.Remove(c.VIN.Find(v => v.VIN == vehicle.VIN));
                        }
                    }
                }
                var color = _context.Colors.Find(vehicle.Color.Color);
                color.VIN.Add(vehicleEntity);
                _context.Colors.Update(color);
            }

            foreach (var el in _context.EquipmentLists)
            {
                if (el.VIN == vehicle.VIN)
                {
                    _context.EquipmentLists.Remove(el);
                }
            }
            foreach (var ve in vehicle.Equipment)
            {
                var el = new EquipmentList
                {
                    VIN = vehicle.VIN,
                    EquipmentID = _context.Equipment.Where(e => e.Equipment == ve.VehicleEquipment).Single().ID,
                };
                _context.EquipmentLists.Add(el);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleDO>> PostVehicle(VehicleDO vehicle)
        {
            if (_context.Vehicles.Find(vehicle.VIN) != null)
            {
                return Conflict();
            }

            var entity = new Vehicle
            {
                VIN = vehicle.VIN,
                LicensePlate = vehicle.LicensePlate,
                Model = vehicle.Model,
            };
            _context.Vehicles.Add(entity);

            if (vehicle.Brand != null)
            {
                if (!_context.BrandSet.Where(b => b.BrandName == vehicle.Brand.Brand).Any())
                {
                    return BadRequest();
                }
                var brand = _context.BrandSet.Find(vehicle.Brand.Brand);
                brand.VIN.Add(entity);
                _context.BrandSet.Update(brand);
            }

            if (vehicle.Fuel != null)
            {
                if (!_context.FuelTypes.Where(f => f.Type == vehicle.Fuel.Fuel).Any())
                {
                    return BadRequest();
                }
                var fuel = _context.FuelTypes.Find(vehicle.Fuel.Fuel);
                fuel.VIN.Add(entity);
                _context.FuelTypes.Update(fuel);
            }

            if (vehicle.Color != null)
            {
                if (!_context.Colors.Where(c => c.ColorName == vehicle.Color.Color).Any())
                {
                    return BadRequest();
                }
                var color = _context.Colors.Find(vehicle.Color.Color);
                color.VIN.Add(entity);
                _context.Colors.Update(color);
            }

            if (vehicle.Equipment.Count > 0)
            {
                foreach (var e in vehicle.Equipment)
                {
                    var el = new EquipmentList
                    {
                        VIN = vehicle.VIN,
                        EquipmentID = _context.Equipment.Where(el => el.Equipment == e.VehicleEquipment).Single().ID,
                    };
                    _context.EquipmentLists.Add(el);
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VIN }, vehicle);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);

            foreach (var el in _context.EquipmentLists)
            {
                if(el.VIN == id){
                    _context.EquipmentLists.Remove(el);
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(string id)
        {
            return _context.Vehicles.Any(e => e.VIN == id);
        }

        private VehicleDO ApplyOptionals(VehicleDO vehicle)
        {
            foreach (var b in _context.BrandSet.ToList())
            {
                if (b.VIN.Exists(bv => bv.VIN == vehicle.VIN))
                {
                    vehicle.Brand = new BrandDO { Brand = b.BrandName };
                }
            }

            foreach (var f in _context.FuelTypes.ToList())
            {
                if (f.VIN.Exists(fv => fv.VIN == vehicle.VIN))
                {
                    vehicle.Fuel = new FuelDO { Fuel = f.Type };
                }
            }

            foreach (var c in _context.Colors.ToList())
            {
                if (c.VIN.Exists(cv => cv.VIN == vehicle.VIN))
                {
                    vehicle.Color = new ColorDO { Color = c.ColorName };
                }
            }

            foreach (var el in _context.EquipmentLists.Where(el => el.VIN == vehicle.VIN).ToList())
            {
                vehicle.Equipment.Add(new VehicleEquipmentDO
                {
                    VehicleEquipment = _context.Equipment.Find(el.EquipmentID).Equipment,
                });
            }

            return vehicle;
        }
    }
}
