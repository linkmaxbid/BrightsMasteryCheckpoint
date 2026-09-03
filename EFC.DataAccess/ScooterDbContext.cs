using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFC.Domain;

namespace EFC.DataAccess;

public class ScooterDbContext : DbContext
{
    
    
public DbSet<Scooter> Scooters => Set<Scooter>();
public DbSet<AppUser> AppUsers => Set<AppUser>();

public DbSet<Trip> Trips => Set<Trip>();




protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql(
            
            "Host = localhost:5433; " +
            "Username = practice_user; " +
            "Password = practice_password;" +
            "Database = scooter;") //sett db navn
        .UseLowerCaseNamingConvention();
    
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    
    modelBuilder.Entity<Trip>()
        .HasOne(t => t.Scooter)
        .WithMany(s => s.Trips)
        .HasForeignKey(t => t.ScooterId);
    
    modelBuilder.Entity<Trip>()
        .HasOne(t => t.AppUser)
        .WithMany(u => u.Trips)
        .HasForeignKey(t => t.AppUserId);
    
}















}