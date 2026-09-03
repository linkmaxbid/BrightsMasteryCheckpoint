using EFC.DataAccess;
using EFC.Domain;
using Moq;
using NUnit.Framework;

namespace EFC.UnitTests;

public class Tests
{
    Mock<IScooterDAO> scooterDao = new Mock<IScooterDAO>();

    [SetUp]
    public void Setup()
    {
        scooterDao.Setup(dao => dao.GetAvailableScootersWithTwentyPercent())
            .Returns(new List<Scooter>
            
            {
                new Scooter
                {
                    Brand = "Voi",
                    BatteryCapacity = 80,
                    Status = Status.Available
                }
                
            });
        
        scooterDao.Setup(dao => dao.GetAllTripsOnGoing())
            .Returns(new List<Trip>
            {
                new Trip
                {
                    AppUserId = 1,
                    ScooterId = 2,
                    EndTime = null
                }
            });
    }

    [Test]
    public void MockAvailableScooter()
    {
        List<Scooter> scooters =
            scooterDao.Object.GetAvailableScootersWithTwentyPercent();
        
        //Sjekker at kun en scooter er i listen 
        Assert.That(scooters.Count, Is.EqualTo(1));
    }
    
    [Test]
    public void MockOngoingTrip()
    {
        List<Trip> trips = scooterDao.Object.GetAllTripsOnGoing();

        //sjekker at kun et trip er lagt til (mocken vår)
        Assert.That(trips.Count, Is.EqualTo(1));
        //sjekker at det trippet har endtime satt til null
        Assert.That(trips[0].EndTime, Is.Null);
    }
}