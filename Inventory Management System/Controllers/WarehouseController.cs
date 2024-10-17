using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly InventoryMSDbContext _context;

        public WarehouseController(InventoryMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Warehouse
        [HttpGet]
        public ActionResult<IEnumerable<Warehouse>> GetWarehouses()
        {
            return _context.Warehouses
                .Include(w => w.Products)   
                .ToList();
        }

        // GET: api/Warehouse/{id}
        [HttpGet("{id}")]
        public ActionResult<Warehouse> GetWarehouse(int id)
        {
            //Get warehouses by id
            var warehouse = _context.Warehouses
                .Include(w => w.Products)   
                .FirstOrDefault(w => w.Id == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // POST: api/Warehouse
        [HttpPost]
        public ActionResult<Warehouse> PostWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();

            return CreatedAtAction("GetWarehouse", new { id = warehouse.Id }, warehouse);
        }

        // PUT: api/Warehouse/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateWarehouse(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(warehouse).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Warehouse/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWarehouse(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
