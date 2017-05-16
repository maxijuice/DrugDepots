using System.Data.Entity;
using Depots.ORM.Entities;

namespace Depots.ORM.Context
{
    public partial class DepotsContext : DbContext
    {
        public DepotsContext()
            : base("name=DepotsContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Depot> Depots { get; set; }
        public virtual DbSet<DrugType> DrugTypes { get; set; }
        public virtual DbSet<DrugUnit> DrugUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Depots)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Depot>()
                .HasMany(e => e.Countries)
                .WithOptional(e => e.Depot)
                .HasForeignKey(e => e.SupplyingDepotId);
        }
    }
}
