using EFC.DataAccess;

using EFC.Domain;

namespace EFC.IntegrationTests;
using NUnit.Framework;


public class IntegrationTests
{
    
    public ScooterDAO ScooterDao = new ScooterDAO();
    
    [SetUp]
    public void Setup()
    {
        ScooterDao.RebuildDatabase();

        using ScooterDbContext db = new();

        AppUser user1 = new AppUser { Name = "Johannes", PhoneNumber = "11111111" };
        AppUser user2 = new AppUser { Name = "Thomas", PhoneNumber = "22222222" };
        AppUser user3 = new AppUser { Name = "Henrik", PhoneNumber = "33333333" };

        Scooter scooter1 = new Scooter { Brand = "Voi", BatteryCapacity = 100, Status = Status.Available };
        Scooter scooter2 = new Scooter { Brand = "Voi", BatteryCapacity = 80, Status = Status.InUse };
        Scooter scooter3 = new Scooter { Brand = "Voi", BatteryCapacity = 15, Status = Status.OutOfOrder };

        db.AppUsers.AddRange(user1, user2, user3);
        db.Scooters.AddRange(scooter1, scooter2, scooter3);
        db.SaveChanges();

        db.Trips.AddRange(
            new Trip
            {
                AppUserId = user1.Id,
                ScooterId = scooter1.Id,
                StartTime = DateTime.UtcNow.AddHours(-3),
                EndTime = DateTime.UtcNow.AddHours(-2),
                Distance = 5,
                Cost = 50
            },
            new Trip
            {
                AppUserId = user2.Id,
                ScooterId = scooter2.Id,
                StartTime = DateTime.UtcNow.AddHours(-2),
                EndTime = DateTime.UtcNow.AddHours(-1),
                Distance = 8,
                Cost = 80
            },
            new Trip
            {
                AppUserId = user1.Id,
                ScooterId = scooter2.Id,
                StartTime = DateTime.UtcNow.AddHours(5),
                Distance = 3,
                Cost = 30
            });

        db.SaveChanges();
        
    }

    [Test]
    public void GetAvailableScootersWithTwentyPercentTest()
    {
        List<Scooter> scooters = ScooterDao.GetAvailableScootersWithTwentyPercent();

        
        //Returnerer den ene som har mer enn 20% og er ledig
        Assert.That(scooters.Count, Is.EqualTo(1));
        Assert.That(scooters[0].BatteryCapacity, Is.EqualTo(100));
    }
    
    
    [Test]
    public void GetAllTripsFromUserTest()
    {
        List<Trip> trips = ScooterDao.GetAllTripsFromUser(1);

        //sjekker at kun turer fra brukeren sin id blir hentet i en liste og at idene stemmeR
        Assert.That(trips.Count, Is.EqualTo(2));
        Assert.That(trips[0].AppUserId, Is.EqualTo(1));
        Assert.That(trips[1].AppUserId, Is.EqualTo(1));
    }
    
    [Test]
    public void GetAllTripsOnGoingTest()
    {
        List<Trip> trips = ScooterDao.GetAllTripsOnGoing();

        //sjekker at kun en trip har ikke fått endtime parameter (skal være null)
        Assert.That(trips.Count, Is.EqualTo(1));
        Assert.That(trips[0].EndTime, Is.Null);
    }
    
    [Test]
    public void GetUserWithMostRidesTest()
    {
        AppUser? user = ScooterDao.GetUserWithMostRides();

        //sjekker at jeg er den med flest turer, siden jeg har 2
        Assert.That(user.Name, Is.EqualTo("Johannes"));
        
    }
    
    [Test]
    public void AvgPricePerKmForAllTripsTest()
    {
        decimal averagePrice = ScooterDao.AvgPricePerKmForAllTrips();

        //siden alle trips er satt til å ha en km pris på 10 burde snittet blant alle være 10 også
        Assert.That(averagePrice, Is.EqualTo(10));
    }
    
    
    //har ikke implementert domenelogikk som gjør at en scooter kan ha 2 turer
    
    
    
    
    
    
    
    
    
    
    
}
