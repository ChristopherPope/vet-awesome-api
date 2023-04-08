using VetAwesome.Bll.RandomDataMakers;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomPetMakerTests
    {
        [Test]
        public void MakePet()
        {
            // ARRANGE
            using var mock = AutoMock.GetLoose();
            var mockUow = mock.Mock<IUnitOfWork>();
            var mockBreedRepo = mock.Mock<IPetBreedRepository>();

            mockUow.Setup(u => u.PetBreeds).Returns(mockBreedRepo.Object);
            var breeds = new List<PetBreedEntity> { new PetBreedEntity(), new PetBreedEntity() };
            mockBreedRepo.Setup(r => r.ReadAll()).Returns(breeds.AsQueryable());

            var maker = mock.Create<RandomPetMaker>();

            // ACT
            var actualPet = maker.MakePets(1).FirstOrDefault();

            // ASSERT
            actualPet.Should().NotBeNull();
            actualPet?.Name.Should().NotBeNullOrWhiteSpace();
            actualPet?.PetBreed.Should().NotBeNull();
        }
    }
}
