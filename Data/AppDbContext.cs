using Microsoft.EntityFrameworkCore;
using NovaApi2.Models.Domain.Usuario;

namespace NovaApi2.Data.UsuarioDbContext
{
    public class AppDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }

}
