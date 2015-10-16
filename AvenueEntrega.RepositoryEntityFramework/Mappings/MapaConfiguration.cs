using System.Data.Entity.ModelConfiguration;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.RepositoryEntityFramework.Mappings
{
    public class MapaConfiguration : EntityTypeConfiguration<Mapa>
    {
        public MapaConfiguration()
        {
            ToTable("tbAvenueEntregaMapas");
            HasKey(m => m.Id);
            Property(m => m.NomeMapa).HasColumnName("NomeMapa");

            HasMany(m => m.Rotas);
        }
    }
}