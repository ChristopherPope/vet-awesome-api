﻿using Microsoft.EntityFrameworkCore;

namespace VetAwesome.Infrastructure;

public sealed class VetAwesomeDb : DbContext
{
    public VetAwesomeDb(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}