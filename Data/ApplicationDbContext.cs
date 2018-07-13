using System;
using learnapp.Model;
using Microsoft.EntityFrameworkCore;

namespace learnapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
        
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=learnapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {            
            modelBuilder.ApplyConfiguration(new ProjectTagConfiguration());
            
            modelBuilder.Entity<Project>().HasData(
                new Project {Id= Guid.NewGuid(), ProjectId="001", Title="Resmap dev"},
                new Project {Id= Guid.NewGuid(), ProjectId="002", Title="Web design"},
                new Project {Id= Guid.NewGuid(), ProjectId="003", Title="Azure impl"}
            );
            modelBuilder.Entity<Tag>().HasData(
                new Tag {Id= Guid.NewGuid(), Title="Web"},
                new Tag {Id= Guid.NewGuid(), Title="Front-end"},
                new Tag {Id= Guid.NewGuid(), Title="Back-end"},
                new Tag {Id= Guid.NewGuid(), Title="Design"},
                new Tag {Id= Guid.NewGuid(), Title="C#"},
                new Tag {Id= Guid.NewGuid(), Title="JavaScript"},
                new Tag {Id= Guid.NewGuid(), Title="Java"}
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id= Guid.NewGuid(), FirstName="Vaidas", LastName="Brazionis", Function="Developer", Department="Estonian"},
                new Employee {Id= Guid.NewGuid(), FirstName="Jonas", LastName="Paulauskas", Function="Manager", Department="Design"},
                new Employee {Id= Guid.NewGuid(), FirstName="Domas", LastName="Zemaitis", Function="Web designer", Department="Design"},
                new Employee {Id= Guid.NewGuid(), FirstName="Sima", LastName="Siniavskaja", Function="Manager", Department="Sales"},
                new Employee {Id= Guid.NewGuid(), FirstName="Algimantas", LastName="Jonauskas", Function="Sales support", Department="Sales"},
                new Employee {Id= Guid.NewGuid(), FirstName="Algis", LastName="Ramanauskas", Function="Developer", Department="Lithuanian"}
            );
        }
    }
    
}