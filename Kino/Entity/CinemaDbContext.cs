using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kino.Entity
{
    public class CinemaDbContext:DbContext
    {
        private readonly string con = @"Server=LAPTOP-A4M3759K\SQLEXPRESS;Database=CinemaDB;Trusted_Connection=True;";
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cinema>().Property(p => p.Email).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Role>().Property(p => p.Id).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Address>().Property(p => p.City).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Address>().Property(p => p.Street).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Film>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Film>().Property(p => p.Start).IsRequired();
           
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(con);
        }


    }
}
