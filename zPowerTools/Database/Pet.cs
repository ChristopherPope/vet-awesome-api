﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VetAwesome.Seeder.Database;

public partial class Pet
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int PetBreedId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Customer Customer { get; set; }

    public virtual PetBreed PetBreed { get; set; }
}