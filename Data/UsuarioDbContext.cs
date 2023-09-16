using NovaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace NovaApi2.Data.UsuarioDbContext
{
    public class UsuarioDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }

    }

}
