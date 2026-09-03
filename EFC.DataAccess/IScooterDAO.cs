﻿using EFC.Domain;

namespace EFC.DataAccess;

public interface IScooterDAO
{
    public void RebuildDatabase();
    
    public List<Scooter> GetAvailableScootersWithTwentyPercent();
    public List<Trip> GetAllTripsFromUser(int appUserId);
    
    public List<Trip> GetAllTripsOnGoing();

    public AppUser? GetUserWithMostRides();

    public decimal AvgPricePerKmForAllTrips();
    
    
}
