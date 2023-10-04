using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareSolution.Models;
using System.ComponentModel.DataAnnotations;


namespace SoftwareSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

       
        private readonly StoreContext _context;

        public AccountController()
        {
            _context = new StoreContext();
        }

        [HttpPost]
        public IActionResult Signup([FromBody] Account account)
        {
            using (var context = new StoreContext())
            {
                var NewUser = new User
                {
                    Name = account.Name,
                    Email = account.Email,
                    Password = account.Password,
                    Balance = account.Balance,
                  
                };

                context.Users.Add(NewUser);
                context.SaveChanges();
            }
            return Ok(account);


        }


        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("I love you XD XD XD");
        }



        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && password == user.Password && email == user.Email)
            {
                return Ok(new { Message = "Login Successfully", Account = user });
            }
            else
            {
                return BadRequest(new { Message = "Email or Password is wrong" });
            }
        }




    }




    /* [HttpGet]
         public IActionResult Get()
         {
             var context = new StoreContext();
             var users = context.Users.ToList();
             return Ok(users);
         }

     }
    */
}
