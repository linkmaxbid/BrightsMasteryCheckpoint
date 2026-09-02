using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFC.Domain;

namespace EFC.DataAccess;

public class EFCDbContext : DbContext
{
    
    
public DbSet<Table1> Table1 => Set<Table1>();
public DbSet<Table2> Table2 => Set<Table2>();



protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql(
            
            "Host = localhost:5433; " +
            "Username = practice_user; " +
            "Password = practice_password;" +
            "Database = samurai;") //sett db navn
        .UseLowerCaseNamingConvention();
    
}


protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    
}









}