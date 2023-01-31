using Microsoft.Data.Sqlite;
using System.Data.Common;
using VetAwesome.Dal.Persistence;

namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public abstract class RepositoryTests
    {
        protected DbContextOptions<VetDbContext> dbContextOptions;
        protected DbConnection dbConnection;

        [SetUp]
        public void SetUp()
        {
            dbConnection = new SqliteConnection("Filename=:memory:");
            dbConnection.Open();

            dbContextOptions = new DbContextOptionsBuilder<VetDbContext>()
                .UseSqlite(dbConnection)
                .Options;

            using var dbContext = CreateContext();
            dbContext.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            using (var dbContext = CreateContext())
            {
                dbContext.Database.EnsureDeleted();
                dbConnection.Close();
            }
        }

        public void Dispose() => dbConnection.Dispose();

        protected VetDbContext CreateContext() => new(dbContextOptions);
    }
}
