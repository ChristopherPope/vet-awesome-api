using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;
internal interface IAddressSeeder : IEntitySeeder
{
    IReadOnlyCollection<Address> Addresses { get; }
}
