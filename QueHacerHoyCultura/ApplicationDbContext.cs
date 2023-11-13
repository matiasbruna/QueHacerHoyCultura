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
    }
}
