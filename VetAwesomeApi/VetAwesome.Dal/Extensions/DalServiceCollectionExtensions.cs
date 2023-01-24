using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using VetAwesome.Dal.Persistence;

namespace VetAwesome.Dal.Extensions
{
    public static class DalServiceCollectionExtensions
    {
        static public IServiceCollection AddVetAwesomeDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<VetDbContext>(options =>
            {
                options.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
                options.UseSqlServer(
                    connectionString,
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });

            return services;
        }
    }
}
