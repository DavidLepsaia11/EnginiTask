using EnginiTask.Domain;
using EnginiTask.Repository.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnginiTask.Repository.Database.Configurations.Domains
{
    internal class EmployeeConfiguration : IEntityConfiguration
    {
        private readonly ModelBuilder _modelBuilder;

        public EmployeeConfiguration(ModelBuilder modelBuilder) => 
            _modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));


        public bool Configure()
        {
            _modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            _modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .HasMaxLength(100);

            _modelBuilder.Entity<Employee>()
                .Property(e => e.ManagerId);

            _modelBuilder.Entity<Employee>()
            .HasMany(e => e.Subordinates)
            .WithOne()
            .HasForeignKey(x => x.ManagerId);

            _modelBuilder.Entity<Employee>()
            .HasIndex(e => new { e.Id });

            return true;
        }
    }
}
