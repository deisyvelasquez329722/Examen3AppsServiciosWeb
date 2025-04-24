using Microsoft.EntityFrameworkCore;
using TorneosApi.Models;

namespace TorneosApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Admin> Administradores { get; set; }
    }
}    