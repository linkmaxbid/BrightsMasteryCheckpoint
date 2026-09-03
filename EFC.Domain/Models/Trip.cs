namespace EFC.Domain;

public class Trip
{
    
    public int Id { get; set; } //PK
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int Distance { get; set; }
    public int Cost { get; set; }
    
    
    public AppUser AppUser { get; set; } = null!; //navigation property
    public int AppUserId { get; set; } //FK

    public Scooter Scooter { get; set; } = null!; //navigation property
    public int ScooterId { get; set; } //FK 
    
    
    
    
    
    
}