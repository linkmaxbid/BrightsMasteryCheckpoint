﻿using System.Runtime.InteropServices.ComTypes;

namespace EFC.DataAccess;
using Microsoft.EntityFrameworkCore;
using EFC.Domain;

public class ScooterDAO :IScooterDAO
{
    
    public void RebuildDatabase()
    
    {
        using ScooterDbContext db = new();

        //Deletes the entire database
        db.Database.EnsureDeleted();

        //Recreates the DB tables, based on the Migrations folder data.
        db.Database.Migrate();
    }

    public List<Scooter> GetAvailableScootersWithTwentyPercent()
    {
        
        using ScooterDbContext db = new();
        
        return db.Scooters.Where(s => s.Status == Status.Available  && s.BatteryCapacity > 20 ).ToList();
        
    }

    public List<Trip> GetAllTripsFromUser(int appUserId)
    {
        
        using ScooterDbContext db = new();  
        
        return db.Trips.Where(t => t.AppUserId == appUserId).OrderBy(t => t.StartTime).ToList();
        
    }

    public List<Trip> GetAllTripsOnGoing()
    {
        using ScooterDbContext db = new();
        
        return db.Trips.Where(s => s.EndTime == null).ToList();
        
    }

    public AppUser? GetUserWithMostRides()
    {
        using ScooterDbContext db = new();

        return db.AppUsers.OrderByDescending(u => u.Trips.Count).FirstOrDefault(); 


    }


    public decimal AvgPricePerKmForAllTrips()
    {
        using ScooterDbContext db = new();

        int totalDistance = db.Trips.Sum(t => t.Distance);
        int totalCosts = db.Trips.Sum(t => t.Cost);

        if (totalDistance == 0)
        {
            return 0;
        }
        
        if (totalCosts == 0)
        {
            return 0;
        }

        return (decimal)totalCosts / (decimal)totalDistance;
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    





}
