using TesteAxado.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace TesteAxado.Infra.Data.EntityConfig
{
    public class CarrierConfiguration : EntityTypeConfiguration<Carrier>
    {

        public CarrierConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
