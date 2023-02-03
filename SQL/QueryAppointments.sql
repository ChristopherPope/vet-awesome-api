select a.Id 'AppointmentId', a.StartTime, a.EndTime, c.Name, c.CellPhone, p.Name 'PetName', t.Name 'TypeOfPet', b.Name 'Breed Name',
u.Name 'Vet' from Appointments a
inner join Pets p on a.PetId = p.Id
inner join PetBreeds b on p.PetBreedId = b.Id
inner join PetTypes t on b.PetTypeId = t.Id
inner join Users u on a.VeterinarianId = u.Id
inner join Customers c on p.CustomerId = c.Id
order by a.StartTime