using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class StateSeeder : EntitySeeder<State>, IStateSeeder
{
    private readonly ILogger<StateSeeder> logger;
    #region State Names
    private readonly List<(string Name, string Abbreviation)> stateNames = new()
    {
        (Name: "Alabama", Abbreviation: "AL" ),
        (Name: "Alaska", Abbreviation: "AK" ),
        (Name: "Arizona", Abbreviation: "AR" ),
        (Name: "Arkansas", Abbreviation: "AR" ),
        (Name: "California", Abbreviation: "CA" ),
        (Name: "Colorado", Abbreviation: "CO" ),
        (Name: "Connecticut", Abbreviation: "CT" ),
        (Name: "Delaware", Abbreviation: "DE" ),
        (Name: "Florida", Abbreviation: "FL" ),
        (Name: "Georgia", Abbreviation: "GA" ),
        (Name: "Hawaii", Abbreviation: "HI" ),
        (Name: "Idaho", Abbreviation: "ID" ),
        (Name: "Illinois", Abbreviation: "IL" ),
        (Name: "Indiana", Abbreviation: "IN" ),
        (Name: "Iowa", Abbreviation: "IA" ),
        (Name: "Kansas", Abbreviation: "KS" ),
        (Name: "Kentucky", Abbreviation: "KY" ),
        (Name: "Louisiana", Abbreviation: "LA" ),
        (Name: "Maine", Abbreviation: "ME" ),
        (Name: "Maryland", Abbreviation: "MD" ),
        (Name: "Massachusetts", Abbreviation: "MA" ),
        (Name: "Michigan", Abbreviation: "MI" ),
        (Name: "Minnesota", Abbreviation: "MN" ),
        (Name: "Mississippi", Abbreviation: "MS" ),
        (Name: "Missouri", Abbreviation: "MO" ),
        (Name: "Montana", Abbreviation: "MT" ),
        (Name: "Nebraska", Abbreviation: "NE" ),
        (Name: "Nevada", Abbreviation: "NV" ),
        (Name: "New Hampshire", Abbreviation: "NH" ),
        (Name: "New Jersey", Abbreviation: "NJ" ),
        (Name: "New Mexico", Abbreviation: "NM" ),
        (Name: "New York", Abbreviation: "NY" ),
        (Name: "North Carolina", Abbreviation: "NC" ),
        (Name: "North Dakota", Abbreviation: "ND" ),
        (Name: "Ohio", Abbreviation: "OH" ),
        (Name: "Oklahoma", Abbreviation: "OK" ),
        (Name: "Oregon", Abbreviation: "OR" ),
        (Name: "Pennsylvania", Abbreviation: "PA" ),
        (Name: "Rhode Island", Abbreviation: "RI" ),
        (Name: "South Carolina", Abbreviation: "SC" ),
        (Name: "South Dakota", Abbreviation: "SD" ),
        (Name: "Tennessee", Abbreviation: "TN" ),
        (Name: "Texas", Abbreviation: "TX" ),
        (Name: "Utah", Abbreviation: "UT" ),
        (Name: "Vermont", Abbreviation: "VT" ),
        (Name: "Virginia", Abbreviation: "VA" ),
        (Name: "Washington", Abbreviation: "WA" ),
        (Name: "West Virginia", Abbreviation: "WV" ),
        (Name: "Wisconsin", Abbreviation: "WI" ),
        (Name: "Wyoming", Abbreviation: "WY" )
    };
    #endregion

    public IReadOnlyCollection<State> States => EntityList;

    public StateSeeder(ILogger<StateSeeder> logger
        , VetAwesomeDb vetDb)
        : base(logger, vetDb)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = new List<State>();

        foreach (var stateName in stateNames)
        {
            var state = State.Create(stateName.Abbreviation, stateName.Name);
            entityList.Add(state);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
