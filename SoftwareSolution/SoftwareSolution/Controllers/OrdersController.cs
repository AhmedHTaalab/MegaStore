using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareSolution.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareSolution.Models;

namespace SoftwareSolution.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrdersController()
        {
            _context = new StoreContext();
        }

        // Retrieve a list of all orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders2>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        // Retrieve details of a specific order by OrderID
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders2>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }

}
