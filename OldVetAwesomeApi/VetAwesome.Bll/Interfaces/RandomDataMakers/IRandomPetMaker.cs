using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomEntityMaker
{
    public interface IRandomPetMaker
    {
        IEnumerable<PetEntity> MakePets(int numPets);
    }
}