using System.Data.Entity.ModelConfiguration;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Infra.Data.EntityConfig
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Rate)
                .IsRequired();

            Property(p => p.Comment)
                .IsOptional()
                .IsMaxLength();

            HasRequired(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            HasRequired(p => p.Carrier)
              .WithMany()
              .HasForeignKey(p => p.CarrierId);
        }
    }
}
