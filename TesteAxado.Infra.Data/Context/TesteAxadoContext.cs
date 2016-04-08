using TesteAxado.Domain.Entities;
using TesteAxado.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace TesteAxado.Infra.Data.Context
{
    public class TesteAxadoContext : DbContext
    {
        public TesteAxadoContext() : base("TesteAxado") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuração de convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configuração default de tabelas
            modelBuilder.Configurations.Add(new CarrierConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());

            //Defaults para campos de banco por tipo
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

        }

        public override int SaveChanges()
        {
            //Aqui pode ser inseridas rotinas a serem executadas antes de alteração no banco

            //Exemplo:
            //Verifica se o objeto alterado possui uma propriedade chamada "InclusionDate" 
            //  e seta a data/hora atual (nos casos de inclusão) ou mantém o valor anterior (nos casos de alteração)
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InclusionDate") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("InclusionDate").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("InclusionDate").IsModified = false;
            //    }
            //}

            return base.SaveChanges();
        }
    }
}
