using FBTarjeta.Models;
using Microsoft.EntityFrameworkCore;

namespace FBTarjeta
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base (options)
        {
            
        }

        public DbSet<TarjetaCredito> TarjetaCreditos { get; set; }
    }
}
