using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shopping.Client.Models
{
    public class ShoppingClientContext : DbContext
    {
        public ShoppingClientContext (DbContextOptions<ShoppingClientContext> options)
            : base(options)
        {
        }

        public DbSet<Shopping.Client.Models.Product> Product { get; set; }
    }
}
