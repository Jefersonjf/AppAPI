using AppAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }    
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
