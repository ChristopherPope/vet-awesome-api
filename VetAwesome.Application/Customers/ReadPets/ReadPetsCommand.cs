using MediatR;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Customers.ReadPets;

public sealed record ReadPetsCommand : IRequest<IEnumerable<Pet>>;
