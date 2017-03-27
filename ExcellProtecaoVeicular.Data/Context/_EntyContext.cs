using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExcellProtecaoVeicular.Model;
namespace ExcellProtecaoVeicular.Data
{
    public class _EntyContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }        
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<Beneficios> Beneficios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public _EntyContext():base("ExcellProtecaoVeicular")
        {
            
        }

        
    }
}