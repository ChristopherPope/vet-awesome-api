using CommunityToolkit.Diagnostics;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders;

internal abstract class EntitySeeder<T> where T : Entity
{
    protected List<T>? entities = null;

    protected IReadOnlyCollection<T> Entities
    {
        get
        {
            Guard.IsNotNull(entities);

            return entities;
        }
    }
}
