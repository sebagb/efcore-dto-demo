﻿using EFCore.Domain.VehicleManagement;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain.Data;

public class DemoContext : DbContext
{
    public DemoContext() { }
    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(x =>
        {
            x.ToTable("Vehicles");

            x.Property<int>("Id");
            x.Property(x => x.VIN).HasConversion(x => x.Value, x => VIN.Create(x));

            x.HasMany<Owner>("owners").WithOne().HasForeignKey("VehicleId");
            x.Navigation("owners").AutoInclude();

            x.Ignore(x => x.CurrentOwner);
            x.Ignore(x => x.PreviousOwners);

            x.HasKey("Id");
        });

        modelBuilder.Entity<Owner>(x =>
        {
            x.ToTable("VehicleOwners");

            x.Property<int>("VehicleId");
            x.HasOne<Person>("person").WithMany().HasForeignKey("PersonId");
            x.Navigation("person").AutoInclude();

            x.Ignore(x => x.Id);
            x.Ignore(x => x.FirstName);
            x.Ignore(x => x.LastName);

            x.HasKey("VehicleId", "PersonId");
        });

        modelBuilder.Entity<Person>(x =>
        {
            x.ToTable("People");

            x.Property(x => x.FirstName).HasColumnName("FirstName");
            x.Property(x => x.LastName).HasColumnName("LastName");

            x.HasKey(x => x.Id);
        });

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
