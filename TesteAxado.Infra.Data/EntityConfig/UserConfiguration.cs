using TesteAxado.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAxado.Infra.Data.EntityConfig
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.UserName)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_user_username") { IsUnique = true }))
                .HasMaxLength(50);

            Property(c => c.Password)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

        }
    }
}
