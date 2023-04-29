using VetAwesome.Domain.Entities;

namespace VetAwesome.Domain.Repositories;
internal interface IPetRepostiory
{
    void Create(Pet pet);
}
