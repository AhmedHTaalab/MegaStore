using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly StoreContext _context;

        public ShoppingController()
        {
            _context = new StoreContext();
        }

        // Add a product to the shopping cart
        [HttpPost("AddtoCart")]
        public async Task<ActionResult> AddToCart(string Name, int quantity, int UserID)
        {
            var user = await _context.Users.FindAsync(UserID);

            // Retrieve the product from the database based on its name
            var product = await _context.Prdoucts.FirstOrDefaultAsync(p => p.Name == Name);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Create a shopping cart item
            var cartItem = new ShoppingCartItem
            {
                ProductId = product.PID, // Assuming PID is the product's unique identifier
                ProductName = product.Name,
                Quantity = quantity,
                TotalPrice = product.Cost * quantity,
                UserID = user.UserID
        };
 
            // Add the new cart item to the database
            _context.ShoppingCartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return Ok("Product added to the shopping cart.");
        }


        [HttpGet("ViewCart/{userId}")]
        public async Task<ActionResult<IEnumerable<ShoppingCartItem>>> ViewCart(int userId)
        {
            var cartItems = await _context.ShoppingCartItems
                .Where(item => item.UserID == userId) // Assuming UserId is stored as a string
                .ToListAsync();

            if (cartItems.Count == 0)
            {
                return NotFound("No shopping cart items found for the specified user.");
            }
            
            return Ok(cartItems);

            
        }



        
        [HttpPost("placeOrder")]
        public async Task<ActionResult> PlaceOrder(string shipMethod, int userId)
        {
           
            var cartItems = await _context.ShoppingCartItems
                .Where(item => item.UserID == userId)
                .ToListAsync(); 


            

             if (cartItems.Count == 0)
              {
                  return BadRequest("Shopping cart is empty. Cannot place an empty order.");
             } 

          

            var order = new Orders2
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                shipMethod = shipMethod,
                OrderItems = cartItems
            };


            
            foreach (var cartItem in cartItems)
            {
                
                order.OrderItems.Add(cartItem); 
            } 


            // Add the new order to the database
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Clear the user's shopping cart
            _context.ShoppingCartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return Ok("Order placed successfully.");
        }

    }
}
