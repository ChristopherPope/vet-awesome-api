using VetAwesome.Bll.Interfaces.RandomEntityMaker;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomPetMaker : RandomDataMaker, IRandomPetMaker
    {
        #region Names
        private readonly List<string> petNames = new()
        {
            "Millie",
            "Maggie",
            "Winston",
            "Athena",
            "Max",
            "Sugar",
            "Samantha",
            "Kobe",
            "Zeus",
            "Lucky",
            "Frankie",
            "Nikki",
            "Cocoa",
            "Callie",
            "Bud",
            "Whiskey",
            "Layla",
            "Katie",
            "Oakley",
            "Dodger",
            "Sparky",
            "Minnie",
            "Nala",
            "Jax",
            "Brady",
            "Dusty",
            "Felix",
            "Misty",
            "Zoe",
            "Murphy",
            "Sweetie",
            "Twiggy",
            "Pumpkin",
            "Salem",
            "BatMan",
            "Loki",
            "Emma",
            "Belle",
            "Beyonce",
            "Izzy",
            "Tucker",
            "Fiona",
            "Daisy",
            "Cher",
            "Chloe",
            "Milo",
            "Harley",
            "Sebastian",
            "Houdini",
            "Sox"
        };
        #endregion
        private readonly List<PetBreedEntity> petBreeds = new();
        private readonly IUnitOfWork uow;

        public RandomPetMaker(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<PetEntity> MakePets(int numPets)
        {
            if (!petBreeds.Any())
            {
                // todo: use Lazy
                petBreeds.AddRange(uow.PetBreeds.ReadAll().ToList());
            }

            List<PetEntity> pets = new List<PetEntity>();
            while (pets.Count < numPets)
            {
                pets.Add(new PetEntity
                {
                    Name = GetRandomElement(petNames),
                    PetBreed = GetRandomElement(petBreeds)
                });
            }

            return pets;
        }
    }
}
