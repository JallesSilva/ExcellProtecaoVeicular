using System.Data.Entity;
using ExcellProtecaoVeicular.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;

namespace ExcellProtecaoVeicular.Repositorio
{
    public class _EntyContext : DbContext
    {
      public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public _EntyContext():base("ExcellProtecaoVeicular")
        {
            
        }
    }
}