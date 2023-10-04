using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace SoftwareSolution.Models
{



    public class Account
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }

}
