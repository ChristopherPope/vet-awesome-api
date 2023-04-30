using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder;

internal class Seeder : IHostedService, IAsyncDisposable
{
    private readonly IStateSeeder stateSeeder;
    private readonly IPetTypeSeeder petTypeSeeder;
    private readonly IPetBreedSeeder breedSeeder;
    private readonly IPetSeeder petSeeder;
    private readonly ICustomerSeeder customerSeeder;
    private readonly ILogger<Seeder> logger;
    private readonly Task completedTask = Task.CompletedTask;
    private Task? task;

    public Seeder(ILogger<Seeder> logger
        , IStateSeeder stateSeeder
        , IPetTypeSeeder petTypeSeeder
        , IPetSeeder petSeeder
        , IPetBreedSeeder breedSeeder
        , ICustomerSeeder customerSeeder)
    {
        this.logger = logger;
        this.stateSeeder = stateSeeder;
        this.petTypeSeeder = petTypeSeeder;
        this.breedSeeder = breedSeeder;
        this.petSeeder = petSeeder;
        this.customerSeeder = customerSeeder;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"The {nameof(Seeder)} is running.");
        var thread = new Thread(new ParameterizedThreadStart(DoWork))
        {
            Name = "Seeder Thread"
        };
        thread.Start(cancellationToken);

        return completedTask;
    }

    private async void DoWork(object? token)
    {
        if (token is null)
        {
            return;
        }

        var cancellationToken = (CancellationToken)token;
        await DeleteEntitiesAsync(cancellationToken);
        await CreateEntitiesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("{Service} is stopping.", nameof(Seeder));

        return completedTask;
    }

    public ValueTask DisposeAsync()
    {
        task?.Dispose();
        return ValueTask.CompletedTask;
    }

    private async Task DeleteEntitiesAsync(CancellationToken cancellationToken)
    {
        var deletionSeeders = new List<IEntitySeeder>()
        {
            petSeeder,
            customerSeeder,
            breedSeeder,
            petTypeSeeder,
            stateSeeder,
        };

        foreach (var seeder in deletionSeeders)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await seeder.DeleteAllAsync(cancellationToken);
        }
    }

    private async Task CreateEntitiesAsync(CancellationToken cancellationToken)
    {
        var creationSeeders = new List<IEntitySeeder>()
        {
            petTypeSeeder,
            breedSeeder,
            stateSeeder,
            customerSeeder,
            petSeeder,
        };

        foreach (var seeder in creationSeeders)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await seeder.CreateAsync(cancellationToken);
        }
    }
}
