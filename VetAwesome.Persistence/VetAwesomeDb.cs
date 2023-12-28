using Microsoft.EntityFrameworkCore;
using VetAwesome.Persistence.Configurations;

namespace VetAwesome.Seeder.Database
{
    public partial class VetAwesomeDb : DbContext
    {
        public VetAwesomeDb(DbContextOptions<VetAwesomeDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            modelBuilder.ApplyConfiguration(new PetBreedConfiguration());
            modelBuilder.ApplyConfiguration(new PetTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
