using Microsoft.EntityFrameworkCore;
using QueHacerHoyCultura.Entidades;

namespace QueHacerHoyCultura
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Provincia> Provincias => Set<Provincia>();
        public DbSet<TipoUsuario> TipoUsuarios => Set<TipoUsuario>();

        public DbSet<Localidad> Localidades => Set<Localidad>();

        public DbSet   <Usuario> Usuarios => Set<Usuario>();

        public DbSet<Eventos> Eventos => Set<Eventos>();

        public DbSet<TipoEvento> TipoEventos => Set<TipoEvento>();


    }
}
