using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<TipoSubscricao> TipoSubscricao { get; set; }
        public DbSet<Genero> Genero { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remover convenções do EF
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Customizar propriedades ao criar BD
            
            //modelBuilder.Properties<string>()
            //     .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new ClienteConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}