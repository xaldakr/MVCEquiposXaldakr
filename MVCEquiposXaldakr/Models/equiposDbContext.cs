using Microsoft.EntityFrameworkCore;

namespace MVCEquiposXaldakr.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions<equiposDbContext> options) : base(options)
        {

        }
        public DbSet<equipos> equipos { get; set; }
        public DbSet<estadosEquipo> estados_equipo { get; set; }
        public DbSet<tipoEquipo> tipo_equipo { get; set; }
        public DbSet<marcas> marcas { get; set; }

    }
}
    