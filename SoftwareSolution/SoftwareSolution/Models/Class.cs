using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SoftwareSolution.Models
{

    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Orders2>Orders { get; set; }
        public DbSet<Product> Prdoucts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-KIBS3RD\MSSQLSERVERITI;Database=BigStore;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public float Balance { get; set; }
  
    }
    
    public class Orders2
    {
      

        [Key]
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string shipMethod { get; set; }

        public List<ShoppingCartItem> OrderItems { get; set; }

    }

    


    public class Product
    {
        [Key]
        public int PID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int Cost { get; set; }
        public int Count { get; set; }
    }

    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserID { get; set; }

       
    
    }

    public class City
    {
        public int CityID { get; set; }

        public string CityName { get; set; }
    }



}



