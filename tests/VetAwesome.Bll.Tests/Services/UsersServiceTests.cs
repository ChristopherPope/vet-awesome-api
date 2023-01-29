using Autofac;
using Autofac.Extras.Moq;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Mapping;
using VetAwesome.Bll.Services;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Bll.Tests.Services
{
    public class UsersServiceTests
    {
        private IMapper? mapper;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            var mappingConfig = new MapperConfiguration(cfg => cfg.AddMaps(new Type[] { typeof(ModelMapping) }));
            mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public void GetUsers()
        {
            if (mapper == null)
            {
                Assert.Fail("this.mapper is NULL.");
                return;
            }

            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(mapper).As<IMapper>());
            // ARRANGE
            var mockUow = mock.Mock<IUnitOfWork>();
            var mockUserRepo = mock.Mock<IUserRepository>();
            mockUow.Setup(u => u.Users).Returns(mockUserRepo.Object);

            var expectedUserEntities = new List<UserEntity>
                {
                    new UserEntity { Id = 1, Name = "Test1" },
                    new UserEntity { Id = 2, Name = "Test2" },
                    new UserEntity { Id = 3, Name = "Test3" },
                };
            var query = expectedUserEntities.AsQueryable();
            mockUserRepo.Setup(r => r.ReadUsers()).Returns(query);

            var expectedUsers = mapper.ProjectTo<User>(query).ToList();
            var svc = mock.Create<UsersService>();

            // ACT
            var actualUsers = svc.GetUsers().ToList();

            // ASSERT
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Test]
        public void Autehenticate()
        {
            using var mock = AutoMock.GetLoose();
            // ARRANGE
            var mockHttpAccessor = mock.Mock<IHttpContextAccessor>();
            var httpContext = new DefaultHttpContext();
            var mockSession = mock.Mock<ISession>();

            mockHttpAccessor.Setup(a => a.HttpContext).Returns(httpContext);
            httpContext.Session = mockSession.Object;

            var svc = mock.Create<UsersService>();

            // ACT
            svc.Authenticate(4455);

            // ASSERT
            mockSession.Verify(s => s.Set(It.Is<string>(s => s == "UserId"), It.IsAny<byte[]>()));
        }
    }
}
