using System.Data.Entity;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryEntityFramework.Mappings;

namespace AvenueEntrega.RepositoryEntityFramework
{
    public class MapaContext : DbContext
    {
        public DbSet<Mapa> Mapas { get; set; }

        public MapaContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapaConfiguration());
            modelBuilder.Configurations.Add(new RotaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}