using Microsoft.EntityFrameworkCore;
using ServicioNW.Models;

namespace ServicioNW.Data
{
    public class NWContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        public NWContext(DbContextOptions<NWContext> options) : base(options) 
        { 
        }
    }
}
