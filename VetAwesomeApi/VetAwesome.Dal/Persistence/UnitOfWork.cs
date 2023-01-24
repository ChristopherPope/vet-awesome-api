using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;
using VetAwesome.Dal.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VetDbContext dbContext;
        private readonly Lazy<IUserRepository> userRepo;
        private readonly Lazy<ICustomerRepository> customerRepo;
        private readonly Lazy<IHouseholdRepository> householdRepo;
        private readonly Lazy<IPetBreedRepository> petBreedRepo;
        private readonly Lazy<IPetRepository> petRepo;
        private readonly Lazy<IRoleRepository> roleRepo;
        private readonly Lazy<IPetTypeRepository> petTypeRepo;
        private readonly Lazy<IAppointmentRepository> appointmentRepo;
        private readonly Lazy<IStatesRepository> statesRepo;

        public IStatesRepository States => statesRepo.Value;
        public IAppointmentRepository Appointments => appointmentRepo.Value;
        public IUserRepository Users => userRepo.Value;
        public ICustomerRepository Customers => customerRepo.Value;
        public IHouseholdRepository Households => householdRepo.Value;
        public IPetBreedRepository PetBreeds => petBreedRepo.Value;
        public IPetRepository Pets => petRepo.Value;
        public IRoleRepository Roles => roleRepo.Value;
        public IPetTypeRepository PetTypes => petTypeRepo.Value;

        public UnitOfWork(VetDbContext dbContext)
        {
            this.dbContext = dbContext;
            appointmentRepo = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(dbContext));
            userRepo = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(dbContext));
            householdRepo = new Lazy<IHouseholdRepository>(() => new HouseholdRepository(dbContext));
            petBreedRepo = new Lazy<IPetBreedRepository>(() => new PetBreedRepository(dbContext));
            petRepo = new Lazy<IPetRepository>(() => new PetRepository(dbContext));
            roleRepo = new Lazy<IRoleRepository>(() => new RoleRepository(dbContext));
            petTypeRepo = new Lazy<IPetTypeRepository>(() => new PetTypeRepository(dbContext));
            statesRepo = new Lazy<IStatesRepository>(() => new StatesRepository(dbContext));
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
