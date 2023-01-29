select a.StartTime, a.EndTime, c.Name, c.PhoneNumber 'CustomerPhone', h.PhoneNumber 'HouseholdPhone', p.Name 'PetName', 
pt.Name 'Animal', pb.Name 'Breed', u.Name 'Veterinarian', r.Name 'UserRole'
from Appointments a
inner join Customers c on a.CustomerId = c.Id
inner join Pets p on a.PetId = p.Id
inner join Users u on a.VeterinarianId = u.Id
inner join PetBreeds pb on p.PetBreedId = pb.Id
inner join PetTypes pt on pb.PetTypeId = pt.Id
inner join Roles r on u.RoleId = r.Id
inner join Households h on c.HouseholdId = h.Id
order by StartTime