using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly InventoryMSDbContext _context;

        public OrderController(InventoryMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _context.Orders.ToList();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
