using Microsoft.Data.Sqlite;
using System.Data.Common;
using VetAwesome.Dal.Persistence;

namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public abstract class RepositoryTests
    {
        protected readonly DbContextOptions<VetDbContext> dbContextOptions;
        protected readonly DbConnection dbConnection;

        public RepositoryTests()
        {
            dbConnection = new SqliteConnection("Filename=:memory:");
            dbConnection.Open();

            dbContextOptions = new DbContextOptionsBuilder<VetDbContext>()
                .UseSqlite(dbConnection)
                .Options;

            using var dbContext = CreateContext();
            dbContext.Database.EnsureCreated();
        }

        public void Dispose() => dbConnection.Dispose();

        protected VetDbContext CreateContext() => new(dbContextOptions);
    }
}
