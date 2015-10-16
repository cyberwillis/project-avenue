using System.Data.Entity.ModelConfiguration;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.RepositoryEntityFramework.Mappings
{
    public class RotaConfiguration : EntityTypeConfiguration<Rota>
    {
        public RotaConfiguration()
        {
            ToTable("tbAvenueEntregaRotas");
            HasKey(r => r.Id);
            Property(r => r.Origem).HasColumnName("Origem");
            Property(r => r.Destino).HasColumnName("Destino");
            Property(r => r.Custo).HasColumnName("Custo");
        }
    }
}